using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public CategoryConfiguration() { }

        public CategoryConfiguration(Category[] initialCategories)
        {
            InitialCategories = initialCategories;
        }

        public Category[] InitialCategories { get; init; } = new Category[0];

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Jobs)
                .WithOne(j => j.Category)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(InitialCategories);
        }
    }
}
