using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class EmploymentTypeConfiguration : IEntityTypeConfiguration<EmploymentType>
    {
        public EmploymentTypeConfiguration() { }

        public EmploymentTypeConfiguration(EmploymentType[] initialEmploymentTypes)
        {
            InitialEmploymentTypes = initialEmploymentTypes;
        }

        public EmploymentType[] InitialEmploymentTypes { get; init; } = new EmploymentType[0];

        public void Configure(EntityTypeBuilder<EmploymentType> builder)
        {
            builder.HasMany(et => et.Jobs)
                .WithOne(j => j.EmploymentType)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(InitialEmploymentTypes);
        }
    }
}
