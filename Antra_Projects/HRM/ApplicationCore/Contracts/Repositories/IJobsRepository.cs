using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobsRepository
{
    Task<List<Job>> GetAllJobs();
    Task<Job> GetJobById(int id);
}