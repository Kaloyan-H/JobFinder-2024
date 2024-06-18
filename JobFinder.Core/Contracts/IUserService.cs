namespace JobFinder.Core.Contracts
{
    public interface IUserService
    {
        public Task<bool> HasCompanyAsync(string userId);
    }
}