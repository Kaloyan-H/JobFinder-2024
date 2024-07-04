using JobFinder.Core.Contracts;

namespace JobFinder.Core.Models.Job
{
    public class JobDeleteViewModel : IJobModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string EmployerId { get; set; } = null!;
    }
}
