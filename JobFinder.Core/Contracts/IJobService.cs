using JobFinder.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Core.Contracts
{
    public interface IJobService
    {
        public Task<bool> ExistsAsync(int jobId);

        public Task<bool> CreateAsync();
    }
}
