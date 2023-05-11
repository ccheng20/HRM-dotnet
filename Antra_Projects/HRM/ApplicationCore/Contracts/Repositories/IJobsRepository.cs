using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobsRepository
{
    List<Job> GetAllJobs();
}