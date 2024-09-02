using JobFinder.Core.Contracts;
using System.Text.RegularExpressions;

namespace JobFinder.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IJobModel jobModel)
            => TurnToValidUrlString(jobModel.Title);

        public static string GetInformation(this ICompanyModel companyModel)
            => TurnToValidUrlString($"{companyModel.Name} {companyModel.Industry}");

        private static string TurnToValidUrlString(string input)
        {
            string result = input;

            result = Regex.Replace(result, @"[^a-zA-Z\-\s]", string.Empty);
            result = Regex.Replace(result, @"\s+", " ").Trim();
            result = result.Replace(" ", "-");

            return result;
        }
    }
}
