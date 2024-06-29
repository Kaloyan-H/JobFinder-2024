using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQueryableJobExtension
    {
        public static IQueryable<JobServiceModel> ProjectToJobServiceModel(this IQueryable<Job> jobs)
        {
            return jobs
                .Select(j => new JobServiceModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Benefits = j.Benefits,
                    CreatedAt = j.CreatedAt,
                    MinSalary = j.MinSalary,
                    MaxSalary = j.MaxSalary,
                    Description = j.Description,
                    Requirements = j.Requirements,
                    Responsibilities = j.Responsibilities,
                    Category = j.Category.Name,
                    CompanyName = j.Company.Name,
                    EmploymentType = j.EmploymentType.Name,
                });
        }
    }
}
