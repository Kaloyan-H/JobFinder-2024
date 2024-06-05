using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public AppUserConfiguration() { }

        public AppUserConfiguration(AppUser[] initialUsers)
        {
            InitialUsers = initialUsers;
        }

        public AppUser[] InitialUsers { get; init; } = new AppUser[0];

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(au => au.OutboundMessages)
                .WithOne(m => m.Sender)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(au => au.InboundMessages)
                .WithOne(m => m.Receiver)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(au => au.Applications)
                .WithOne(a => a.Applicant)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(au => au.Company)
                .WithOne(c => c.Employer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(InitialUsers);
        }
    }
}
