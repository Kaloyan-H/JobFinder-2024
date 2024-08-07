using JobFinder.Core.Models.Company;

namespace JobFinder.Core.Contracts
{
    public interface ICompanyService
    {
        public Task<bool> ExistsAsync(int companyId);

        public Task<int> CreateAsync(CompanyCreateFormModel model);

        public Task<int> EditAsync(CompanyEditFormModel model);

        public Task<CompanyQueryServiceModel> AllAsync(AllCompaniesQueryModel queryModel);

        public Task<CompanyDetailsViewModel> GetCompanyDetailsModelAsync(int companyId);

        public Task<CompanyEditFormModel> GetCompanyEditModelAsync(int companyId);

        public Task<bool> CompanyIsOwnedByEmployerAsync(int companyId, string employerId);
    }
}
