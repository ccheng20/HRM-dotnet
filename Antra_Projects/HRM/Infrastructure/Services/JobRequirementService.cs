using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class JobRequirementService : IJobRequirementService
{
    private readonly IJobRequirementRepository _jobRequirementRepository;

    public JobRequirementService(IJobRequirementRepository jobRequirementRepository)
    {
        _jobRequirementRepository = jobRequirementRepository;
    }
    public async Task<List<JobResponseModel>> GetPaginatedJobs(int pageNumber=1, int pageSize=30)
    {
        var jobRequirements = await _jobRequirementRepository.GetAllJobRequirements();
        var jobResponseModels = jobRequirements.Select(jr => new JobResponseModel
        {
            Id = jr.Id,
            Title = jr.Title,
            Description = jr.Description,
        });

        var paginatedJobResponseModels = jobResponseModels.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return paginatedJobResponseModels.ToList();
    }
    }
