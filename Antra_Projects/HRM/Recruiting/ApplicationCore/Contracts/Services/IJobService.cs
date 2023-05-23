using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobService
{
    Task<List<JobResponseModel>> GetAllJobs();
    Task<JobResponseModel> GetJobById(int id);
    Task<int> AddJob(JobRequestModel model);

    Task<int?> UpdateJob(JobRequestModel model, int id);
    Task<int?> DeleteJob(int id);
}