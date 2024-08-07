using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Models.Company
{
    public class CompanyDetailsViewModel : ICompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Industry { get; set; } = null!;

        public string EmployerId { get; set; } = null!;

        public IEnumerable<JobServiceModel> Jobs { get; set; }
            = new List<JobServiceModel>();
    }
}
