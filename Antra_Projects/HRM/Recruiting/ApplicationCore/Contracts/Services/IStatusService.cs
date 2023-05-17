using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IStatusService
{
    Task<List<JobStatusResponseModel>> GetAllStatus();
    Task<JobStatusResponseModel> GetStatusById(int id);
    Task DeleteStatus(int id);
    Task<int> AddStatus(JobStatusRequestModel model);
    Task<int> UpdateStatus(JobStatusRequestModel model, int id);
}