using System.ComponentModel.DataAnnotations;

namespace JobFinder.Core.Models.Job
{
    public class JobServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public string? Responsibilities { get; set; }
                     
        public string? Benefits { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public string Category { get; set; } = null!;

        public string EmploymentType { get; set; } = null!;

        public string CompanyName { get; set; } = null!;
    }
}
