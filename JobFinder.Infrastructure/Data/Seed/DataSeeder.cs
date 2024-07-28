using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace JobFinder.Infrastructure.Data.Seed
{
    internal class DataSeeder
    {
        public DataSeeder()
        {
            SeedUsers();
            SeedCategories();
            SeedEmploymentTypes();
        }

        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
        public IEnumerable<AppUser> Users { get; set; } = new List<AppUser>();
        public IEnumerable<Message> Messages { get; set; } = new List<Message>();
        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Application> Applications { get; set; } = new List<Application>();
        public IEnumerable<EmploymentType> EmploymentTypes { get; set; } = new List<EmploymentType>();

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Admin",
                LastName = "Adminson",
                Bio = "I'm an admin and I moderate."
            };
            
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "adminPass123");

            Users = Users
                .Append(adminUser);
        }

        private void SeedCategories()
        {
            Categories = Categories
                .Append(new Category
                {
                    Id = 1,
                    Name = "IT"
                })
                .Append(new Category
                {
                    Id = 2,
                    Name = "Creative"
                })
                .Append(new Category
                {
                    Id = 3,
                    Name = "Marketing"
                });
        }
        private void SeedEmploymentTypes()
        {
            EmploymentTypes = EmploymentTypes
                .Append(new EmploymentType
                {
                    Id = 1,
                    Name = "Full-time"
                })
                .Append(new EmploymentType
                {
                    Id = 2,
                    Name = "Part-time"
                })
                .Append(new EmploymentType
                {
                    Id = 3,
                    Name = "Contract"
                })
                .Append(new EmploymentType
                {
                    Id = 4,
                    Name = "Internship"
                });
        }
    }
}
