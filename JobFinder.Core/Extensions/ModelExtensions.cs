using JobFinder.Core.Contracts;
using System.Text.RegularExpressions;

namespace JobFinder.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IJobModel jobModel)
        {
            string result = jobModel.Title;

            result = Regex.Replace(result, @"[^a-zA-Z\-\s]", string.Empty);
            result = Regex.Replace(result, @"\s+", " ").Trim();
            result = result.Replace(" ", "-");

            return result;
        }
    }
}
