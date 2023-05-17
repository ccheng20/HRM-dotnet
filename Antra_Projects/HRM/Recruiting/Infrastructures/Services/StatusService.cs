using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ClassLibrary1.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task<List<JobStatusResponseModel>> GetAllStatus()
    {
        var allStatus = await _statusRepository.GetAllAsync();
        var statusModels = new List<JobStatusResponseModel>();
        foreach (var status in allStatus)
        {
            statusModels.Add(new JobStatusResponseModel()
            {
                Id = status.Id,
                JobStatusCode = status.JobStatusCode,
                JobStatusDescription = status.JobStatusDescription
            });
        }

        return statusModels;
    }

    public async Task<JobStatusResponseModel> GetStatusById(int id)
    {
        var status = await _statusRepository.GetByIdAsync(id);
        if (status == null) return null;
        var statusResponseModel = new JobStatusResponseModel()
        {
            Id = status.Id,
            JobStatusCode = status.JobStatusCode,
            JobStatusDescription = status.JobStatusDescription
        };
        return statusResponseModel;
    }

    public async Task DeleteStatus(int id)
    {
        var status = await _statusRepository.GetByIdAsync(id);
        if (status != null)
        {
            await _statusRepository.DeleteAsync(id);
        }
        
    }

    public async Task<int> AddStatus(JobStatusRequestModel model)
    {
        var statusEntity = new JobStatusLookUp()
        {
            JobStatusCode = model.JobStatusCode,
            JobStatusDescription = model.JobStatusDescription
        };
        var status = await _statusRepository.AddAsync(statusEntity);
        return status.Id;
    }

    public async Task<int> UpdateStatus(JobStatusRequestModel model, int id)
    {

        var existingStatus = await _statusRepository.GetByIdAsync(id);
        if (existingStatus != null)
        {
            existingStatus.JobStatusCode = model.JobStatusCode;
            existingStatus.JobStatusDescription = model.JobStatusDescription;
        }

        var status = await _statusRepository.UpdateAsync(existingStatus);
        return status.Id;
    }
}