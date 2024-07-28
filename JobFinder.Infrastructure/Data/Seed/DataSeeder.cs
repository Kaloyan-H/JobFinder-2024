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

            var recruiterUser = new AppUser
            {
                Id = "206e17be-be9a-4fb6-92e7-9399f462cd94",
                UserName = "recruiter",
                NormalizedUserName = "RECRUITER",
                Email = "recruiter@mail.com",
                NormalizedEmail = "RECRUITER@MAIL.COM",
                FirstName = "Recruiter",
                LastName = "Recruiterson",
                Bio = "I'm a recruiter and I recruit people."
            };

            var jobSeekerUser = new AppUser
            {
                Id = "a6391dd9-9706-4ebb-b00b-3efa5e49a53f",
                UserName = "jobseeker",
                NormalizedUserName = "JOBSEEKER",
                Email = "jobseeker@mail.com",
                NormalizedEmail = "JOBSEEKER@MAIL.COM",
                FirstName = "Job",
                LastName = "Seeker",
                Bio = "I'm a job seeker and I'm looking for a job."
            };
            
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "adminPass123");
            recruiterUser.PasswordHash = hasher.HashPassword(recruiterUser, "recruiter123");
            jobSeekerUser.PasswordHash = hasher.HashPassword(jobSeekerUser, ",J56])gV8dp*2wq");

            Users
                .Append(adminUser)
                .Append(recruiterUser)
                .Append(jobSeekerUser);
        }

        private void SeedCategories()
        {
            Categories
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
            EmploymentTypes
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
