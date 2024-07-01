namespace JobFinder.Core.Models.Application
{
    public class ApplicationDetailsViewModel
    {
        public string JobTitle { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string ApplicantFirstName { get; set; } = null!;
        
        public string ApplicantLastName { get; set; } = null!;

        public string ApplicantEmail { get; set; } = null!;

        public string CoverLetter { get; set; } = null!;

        public string ResumeURL { get; set; } = null!;
    }
}
