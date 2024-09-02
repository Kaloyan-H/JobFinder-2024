using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.Core.Models.EmploymentType
{
    public class EmploymentTypeDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int NewEmploymentTypeId { get; set; }

        public IEnumerable<EmploymentTypeServiceModel> EmploymentTypes { get; set; }
            = new List<EmploymentTypeServiceModel>();
    }
}
