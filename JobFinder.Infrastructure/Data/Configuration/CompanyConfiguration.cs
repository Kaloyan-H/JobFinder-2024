using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public CompanyConfiguration() { }

        public CompanyConfiguration(Company[] initialCompanies)
        {
            InitialCompanies = initialCompanies;
        }

        public Company[] InitialCompanies { get; init; } = new Company[0];

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(InitialCompanies);
        }
    }
}
