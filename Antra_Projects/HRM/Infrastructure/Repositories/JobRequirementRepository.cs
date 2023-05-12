using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class JobRequirementRepository : IJobRequirementRepository
{
    public Task<List<JobResponseModel>> GetAllJobRequirements()
    {
        throw new NotImplementedException();
    }
}