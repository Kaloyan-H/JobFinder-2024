using JobFinder.Core.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtension
    {
        public static async Task SeedRolesAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var roleInitializer = scope.ServiceProvider.GetRequiredService<IRoleInitializer>();
            await roleInitializer.InitializeRolesAsync();
        }
    }
}
