using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Company;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repository;
        private readonly IJobService jobService;

        public CompanyService(
            IRepository _repository,
            IJobService _jobService)
        {
            repository = _repository;
            jobService = _jobService;
        }

        public async Task<bool> ExistsAsync(int companyId)
            => await repository
                .AllReadOnly<Company>()
                .AnyAsync(c => c.Id == companyId);

        public async Task<int> CreateAsync(CompanyCreateFormModel model)
        {
            if (model.EmployerId == null)
            {
                throw new ArgumentNullException(nameof(model.EmployerId));
            }

            Company company = new Company()
            {
                Name = model.Name,
                Description = model.Description,
                Industry = model.Industry,
                EmployerId = model.EmployerId
            };

            await repository.AddAsync(company);
            await repository.SaveChangesAsync();

            return company.Id;
        }

        public async Task<int> EditAsync(CompanyEditFormModel model)
        {
            var company = await repository.GetByIdAsync<Company>(model.Id);

            if (company != null)
            {
                company.Name = model.Name;
                company.Description = model.Description;
                company.Industry = model.Industry;

                await repository.SaveChangesAsync();

                return company.Id;
            }

            return 0;
        }

        public async Task<CompanyQueryServiceModel> AllAsync(AllCompaniesQueryModel queryModel)
        {
            var companies = repository.AllReadOnly<Company>();

            if (queryModel.SearchTerm != null)
            {
                string normalizedSearchTerm = queryModel.SearchTerm.ToLower();
                companies = companies
                    .Where(c =>
                        c.Name.ToLower().Contains(normalizedSearchTerm) ||
                        c.Industry.ToLower().Contains(normalizedSearchTerm) ||
                        c.Description.ToLower().Contains(normalizedSearchTerm));
            }

            var companiesToShow = await companies
                .Skip((queryModel.CurrentPage - 1) * AllCompaniesQueryModel.CompaniesPerPage)
                .Take(AllCompaniesQueryModel.CompaniesPerPage)
                .ProjectToCompanyServiceModel()
                .ToListAsync();

            int totalCompanies = await companies.CountAsync();

            return new CompanyQueryServiceModel()
            {
                Companies = companiesToShow,
                TotalCompaniesCount = totalCompanies,
            };
        }

        public async Task<CompanyDetailsViewModel> GetCompanyDetailsModelAsync(int companyId)
        {
            Company company = await GetCompanyReadOnlyAsync(companyId);

            IEnumerable<JobServiceModel> jobs = await jobService.AllJobsByCompanyIdAsync(companyId);

            return new CompanyDetailsViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Industry = company.Industry,
                EmployerId = company.EmployerId,
                Jobs = jobs
            };
        }

        public async Task<CompanyEditFormModel> GetCompanyEditModelAsync(int companyId)
        {
            Company company = await GetCompanyReadOnlyAsync(companyId);

            return new CompanyEditFormModel()
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Industry = company.Industry,
                EmployerId = company.EmployerId
            };
        }

        public async Task<Company> GetCompanyReadOnlyAsync(int companyId)
        {
            var company = await repository.AllReadOnly<Company>()
                .Include(j => j.Employer)
                .FirstOrDefaultAsync(c => c.Id == companyId);

            if (company == null)
            {
                throw new ArgumentException(ErrorMessages.CompanyDoesNotExistErrorMessage, nameof(companyId));
            }

            return company;
        }

        public async Task<bool> CompanyIsOwnedByEmployerAsync(int companyId, string employerId)
        {
            return await repository.AllReadOnly<Company>()
                .AnyAsync(c => c.Id == companyId && c.EmployerId == employerId);
        }
    }
}
