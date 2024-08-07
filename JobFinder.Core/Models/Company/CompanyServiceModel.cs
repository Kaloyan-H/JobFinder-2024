using JobFinder.Core.Contracts;

namespace JobFinder.Core.Models.Company
{
    public class CompanyServiceModel : ICompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Industry { get; set; } = null!;
    }
}
