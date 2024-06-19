using JobFinder.Infrastructure.Data.Configuration;
using JobFinder.Infrastructure.Data.Models;
using JobFinder.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<AppRole> AppRoles { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Application> Applications { get; set; } = null!;
        public DbSet<EmploymentType> EmploymentTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DataSeeder dataSeeder = new DataSeeder();

            builder.ApplyConfiguration(new JobConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration(dataSeeder.Categories.ToArray()));
            builder.ApplyConfiguration(new ApplicationConfiguration());
            builder.ApplyConfiguration(new EmploymentTypeConfiguration(dataSeeder.EmploymentTypes.ToArray()));

            base.OnModelCreating(builder);
        }
    }
}
