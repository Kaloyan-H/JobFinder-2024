using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public JobConfiguration() { }

        public JobConfiguration(Job[] initialJobs)
        {
            InitialJobs = initialJobs;
        }

        public Job[] InitialJobs { get; init; } = new Job[0];

        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasMany(j => j.Applications)
                .WithOne(a => a.Job)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(InitialJobs);
        }
    }
}
