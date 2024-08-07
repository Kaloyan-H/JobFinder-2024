using JobFinder.Core.Models.Company;
using JobFinder.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQueryableCompanyExtension
    {
        public static IQueryable<CompanyServiceModel> ProjectToCompanyServiceModel(this IQueryable<Company> companies)
        {
            return companies
                .Select(c => new CompanyServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Industry = c.Industry,
                    Description = c.Description
                });
        }
    }
}
