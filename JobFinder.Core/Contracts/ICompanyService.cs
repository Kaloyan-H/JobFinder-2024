using JobFinder.Core.Models.Company;

namespace JobFinder.Core.Contracts
{
    public interface ICompanyService
    {
        /// <summary>
        /// Asynchronously checks if the given company exists in the database.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns>True if the company exists.</returns>
        public Task<bool> ExistsAsync(int companyId);

        /// <summary>
        /// Asynchronously creates a new company entity and adds it to the database.
        /// </summary>
        /// <param name="model">The company DTO.</param>
        /// <returns>The newly created company id.</returns>
        public Task<int> CreateAsync(CompanyCreateFormModel model);

        /// <summary>
        /// Asynchronously edits the given company and saves the changes in the database.
        /// </summary>
        /// <param name="model">The company DTO.</param>
        /// <returns>The company id.</returns>
        public Task<int> EditAsync(CompanyEditFormModel model);

        /// <summary>
        /// Asynchronously finds all companies that fit the given criteria.
        /// </summary>
        /// <param name="queryModel">The job query model.</param>
        /// <returns>A view model with all companies that fit the criteria.</returns>
        public Task<CompanyQueryServiceModel> AllAsync(AllCompaniesQueryModel queryModel);

        /// <summary>
        /// Asynchronously creates a company view model for the company Details view.
        /// </summary>
        /// <param name="jobId">The company id.</param>
        /// <returns>A view model.</returns>
        public Task<CompanyDetailsViewModel> GetCompanyDetailsModelAsync(int companyId);

        /// <summary>
        /// Asynchronously creates a company form model for the company Edit view.
        /// </summary>
        /// <param name="jobId">The company id.</param>
        /// <returns>A form model.</returns>
        public Task<CompanyEditFormModel> GetCompanyEditModelAsync(int companyId);

        /// <summary>
        /// Asynchronously checks if the given company is owned by the given employer.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="employerId">The employer id.</param>
        /// <returns>True if the company is owned by the employer.</returns>
        public Task<bool> CompanyIsOwnedByEmployerAsync(int companyId, string employerId);
    }
}
