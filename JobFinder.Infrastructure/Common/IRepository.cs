namespace JobFinder.Infrastructure.Common
{
    public interface IRepository
    {
        public Task<T?> GetByIdAsync<T>(object id) where T : class;

        public IQueryable<T> All<T>() where T : class;

        public IQueryable<T> AllReadOnly<T>() where T : class;
        
        public Task AddAsync<T>(T entity) where T : class;
        
        public void Delete<T>(T entity) where T : class;

        public void BatchDelete<T>(IEnumerable<T> entities) where T : class;
        
        public Task<int> SaveChangesAsync();
    }
}
