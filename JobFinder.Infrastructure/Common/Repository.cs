using JobFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Infrastructure.Common
{
    public class Repository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Retrieves all entities of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of entity to retrieve.</typeparam>
        /// <returns>An IQueriable representing all entities of the specified type.</returns>
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        /// <summary>
        /// Retrieves all entities of the specified type without a change tracker.
        /// </summary>
        /// <typeparam name="T">The type of entity to retrieve.</typeparam>
        /// <returns>An IQueriable representing all entities of the specified type.</returns>
        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        /// <summary>
        /// Asynchronously adds an entity of the specified type to it's corresponding DbSet.
        /// </summary>
        /// <typeparam name="T">The type of entity to add.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        /// <returns></returns>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Asycnhronously saves changes to the DB context.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
