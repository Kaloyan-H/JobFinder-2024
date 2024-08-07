using System.ComponentModel.DataAnnotations;

namespace JobFinder.Core.Models.Company
{
    public class AllCompaniesQueryModel
    {
        public const int CompaniesPerPage = 9;

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; } = null;

        public string? EmployerId { get; set; } = null;

        public int CurrentPage { get; set; } = 1;

        public int TotalCompaniesCount { get; set; }

        public IEnumerable<CompanyServiceModel> Companies { get; set; }
            = new List<CompanyServiceModel>();
    }
}
