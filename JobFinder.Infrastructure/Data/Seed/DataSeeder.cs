using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Infrastructure.Data.Seed
{
    internal class DataSeeder
    {
        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
        public IEnumerable<AppUser> Users { get; set; } = new List<AppUser>();
        public IEnumerable<Message> Messages { get; set; } = new List<Message>();
        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Application> Applications { get; set; } = new List<Application>();
        public IEnumerable<EmploymentType> EmploymentTypes { get; set; } = new List<EmploymentType>();

        public DataSeeder()
        {
            SeedCategories();
            SeedEmploymentTypes();
        }

        private void SeedCategories()
        {
            Categories = new List<Category>()
                .Append(new Category()
                {
                    Id = 1,
                    Name = "IT"
                })
                .Append(new Category()
                {
                    Id = 2,
                    Name = "Creative"
                })
                .Append(new Category()
                {
                    Id = 3,
                    Name = "Marketing"
                });
        }
        private void SeedEmploymentTypes()
        {
            EmploymentTypes = new List<EmploymentType>()
                .Append(new EmploymentType()
                {
                    Id = 1,
                    Name = "Full-time"
                })
                .Append(new EmploymentType()
                {
                    Id = 2,
                    Name = "Part-time"
                })
                .Append(new EmploymentType()
                {
                    Id = 3,
                    Name = "Contract"
                })
                .Append(new EmploymentType()
                {
                    Id = 4,
                    Name = "Internship"
                });
        }
    }
}
