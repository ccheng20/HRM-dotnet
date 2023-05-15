using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobsRepository : IRepository<Job>
{
    Task<List<Job>> GetAllJobs();
    Task<Job> GetJobById(int id);

    Task<List<Job>> GetJobsByTitle(string title);
}