using JobFinder.Core.Models.EmploymentType;
using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Core.Contracts
{
    public interface IEmploymentTypeService
    {
        /// <summary>
        /// Asynchronously checks whether the given employment type exists in the database.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <returns>True if the employment type exists.</returns>
        public Task<bool> ExistsAsync(int employmentTypeId);

        /// <summary>
        /// Asynchronously finds all employment types.
        /// </summary>
        /// <returns>A collection of employment type DTOs.</returns>
        public Task<IEnumerable<EmploymentTypeServiceModel>> AllAsync();

        /// <summary>
        /// Asynchronously finds all employment types except the given one.
        /// </summary>
        /// <param name="employmentTypeId">The employment type to be excluded id.</param>
        /// <returns>A collection of employment type DTOs.</returns>
        public Task<IEnumerable<EmploymentTypeServiceModel>> AllExceptAsync(int employmentTypeId);

        /// <summary>
        /// Asynchronously creates a new employment type entity and adds it to the database.
        /// </summary>
        /// <param name="model">The employment type DTO.</param>
        /// <returns>The newly created employment type id.</returns>
        public Task<int> CreateAsync(EmploymentTypeCreateFormModel model);


        /// <summary>
        /// Asynchronously edits the given employment type and saves the changes in the database.
        /// </summary>
        /// <param name="model">The employment type DTO.</param>
        /// <returns>The employment type id or 0 if the entity isn't found.</returns>
        public Task<int> EditAsync(EmploymentTypeEditFormModel model);

        /// <summary>
        /// Asynchronously deletes the given employment type from the database and moves all jobs from that employment type to the new given employment type.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <param name="newEmploymentTypeId">The new employment type id.</param>
        /// <returns>True if the deletion was successful.</returns>
        public Task<bool> DeleteAsync(int employmentTypeId, int newEmploymentTypeId);

        /// <summary>
        /// Asynchronously creates a employment type form model for the employment type Edit view.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <returns>A form model.</returns>
        public Task<EmploymentTypeEditFormModel> GetEmploymentTypeEditModelAsync(int employmentTypeId);

        /// <summary>
        /// Asynchronously creates a employment type view model for the employment type Delete view.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <returns>A view model.</returns>
        public Task<EmploymentTypeDeleteViewModel> GetEmploymentTypeDeleteModelAsync(int employmentTypeId);

        /// <summary>
        /// Asynchronously finds a employment type entity from the database without change tracking.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <returns>A employment type entity.</returns>
        public Task<EmploymentType> GetEmploymentTypeReadOnlyAsync(int employmentTypeId);
    }
}
