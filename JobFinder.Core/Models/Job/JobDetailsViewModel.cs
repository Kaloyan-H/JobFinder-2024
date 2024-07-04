using JobFinder.Core.Contracts;

namespace JobFinder.Core.Models.Job
{
    public class JobDetailsViewModel : IJobModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public string? Responsibilities { get; set; }

        public string? Benefits { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Category { get; set; } = null!;

        public string EmploymentType { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public int CompanyId { get; set; }

        public string EmployerId { get; set; } = null!;

        public IEnumerable<JobApplicationServiceModel> Applications { get; set; }
            = new List<JobApplicationServiceModel>();
    }
}
