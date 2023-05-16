using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobRequirementService
{
    Task<List<JobResponseModel>> GetPaginatedJobs(int pageNumber=1, int pageSize = 30);
}