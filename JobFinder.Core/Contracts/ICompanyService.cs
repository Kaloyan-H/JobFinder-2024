using JobFinder.Core.Models.Company;

namespace JobFinder.Core.Contracts
{
    public interface ICompanyService
    {
        public Task<int> CreateAsync(CompanyCreateFormModel model);

        public Task<CompanyViewModel?> GetCompanyAsync(int companyId);
    }
}
