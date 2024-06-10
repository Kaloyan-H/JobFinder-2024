using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class JobService : IJobService
    {
        private IRepository repository;

        public JobService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsAsync(int jobId)
        {
            return await repository.AllReadOnly<Job>()
                .AnyAsync(j => j.Id == jobId);
        }

        public async Task<bool> CreateAsync()
        {
            throw new NotImplementedException();
        }

    }
}
