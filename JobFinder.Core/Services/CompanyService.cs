using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Company;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repository;

        public CompanyService(
            IRepository _repository)
        {
            repository = _repository;
        }

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

        public async Task<CompanyViewModel?> GetCompanyAsync(int companyId)
        {
            return await repository.All<Company>()
                .Where(c => c.Id == companyId)
                .Select(c => new CompanyViewModel()
                {
                    Name = c.Name,
                    Description = c.Description,
                    Industry = c.Industry,
                })
                .FirstOrDefaultAsync();
        }
    }
}
