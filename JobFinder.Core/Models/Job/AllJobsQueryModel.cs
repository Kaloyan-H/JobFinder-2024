using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.Core.Models.Job
{
    public class AllJobsQueryModel
    {
        public const int JobsPerPage = 9;

        [Display(Name = "Category")]
        public int? CategoryId { get; set; } = null;

        [Display(Name = "Employment type")]
        public int? EmploymentTypeId { get; set; } = null;

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; } = null;

        public JobSortingEnum Sorting { get; set; } = JobSortingEnum.NewestFirst;

        public int CurrentPage { get; set; } = 1;

        public int TotalJobsCount { get; set; }

        public IEnumerable<JobServiceModel> Jobs { get; set; }
            = new List<JobServiceModel>();

        public IEnumerable<JobCategoryServiceModel> Categories { get; set; }
            = new List<JobCategoryServiceModel>();

        public IEnumerable<JobEmploymentTypeServiceModel> EmploymentTypes { get; set; }
            = new List<JobEmploymentTypeServiceModel>();
    }
}
