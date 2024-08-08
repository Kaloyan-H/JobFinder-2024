namespace JobFinder.Core.Contracts
{
    public interface IRoleInitializer
    {
        /// <summary>
        /// Initializes all roles.
        /// </summary>
        public Task InitializeRolesAsync();
    }
}
