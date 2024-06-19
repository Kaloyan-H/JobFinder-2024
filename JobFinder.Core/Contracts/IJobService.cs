﻿using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface IJobService
    {
        public Task<bool> ExistsAsync(int jobId);

        /// <summary>
        /// Asynchronously creates a new Job entity model and adds it to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Job Id</returns>
        public Task<int> CreateAsync(JobCreateViewModel model, int companyId);
    }
}
