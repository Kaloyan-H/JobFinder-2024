namespace JobFinder.Core.Models.Company
{
    public class CompanyQueryServiceModel
    {
        public int TotalCompaniesCount { get; set; }

        public IEnumerable<CompanyServiceModel> Companies { get; set; }
            = new List<CompanyServiceModel>();
    }
}
