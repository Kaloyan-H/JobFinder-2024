using JobFinder.Core.Models.Category;
using JobFinder.Core.Models.EmploymentType;
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

        public string? EmployerId { get; set; } = null;

        public int CurrentPage { get; set; } = 1;

        public int TotalJobsCount { get; set; }

        public IEnumerable<JobServiceModel> Jobs { get; set; }
            = new List<JobServiceModel>();

        public IEnumerable<CategoryServiceModel> Categories { get; set; }
            = new List<CategoryServiceModel>();

        public IEnumerable<EmploymentTypeServiceModel> EmploymentTypes { get; set; }
            = new List<EmploymentTypeServiceModel>();
    }
}
