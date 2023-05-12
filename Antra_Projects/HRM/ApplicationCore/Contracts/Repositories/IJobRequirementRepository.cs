using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRequirementRepository
{
  Task<List<JobResponseModel>> GetAllJobRequirements();
}