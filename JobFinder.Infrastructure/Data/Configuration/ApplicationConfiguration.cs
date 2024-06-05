using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public ApplicationConfiguration() { }

        public ApplicationConfiguration(Application[] initialApplications)
        {
            InitialApplications = initialApplications;
        }

        public Application[] InitialApplications { get; init; } = new Application[0];

        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasData(InitialApplications);
        }
    }
}
