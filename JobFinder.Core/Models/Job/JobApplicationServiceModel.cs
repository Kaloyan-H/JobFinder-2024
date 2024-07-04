namespace JobFinder.Core.Models.Job
{
    public class JobApplicationServiceModel
    {
        public int Id { get; set; }

        public string ApplicantFirstName { get; set; } = null!;

        public string ApplicantLastName { get; set; } = null!;

        public string ApplicantEmail { get; set; } = null!;
    }
}
