

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ClassLibrary1.Services;

public class JobService : IJobService
{
    private readonly IJobsRepository _jobsRepository;
    public JobService(IJobsRepository jobsRepository)
    {
        _jobsRepository = jobsRepository;
    }
    public async Task<List<JobResponseModel>> GetAllJobs()
    {
        var jobs = await _jobsRepository.GetAllJobs();
        var jobsResponseModel = new List<JobResponseModel>();
        foreach (var job in jobs)
        {
            jobsResponseModel.Add( new JobResponseModel()
            {
                Id= job.Id, Description = job.Description, Title = job.Title, 
                StartDate = job.StartDate.GetValueOrDefault(), NumberOfPositions = job.NumberOfPositions,
                JobCode = job.JobCode
            });
        }

        return jobsResponseModel;
    }

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobsRepository.GetJobById(id);
        if (job == null)
        {
            return null;
        }
        var jobResponseModel = new JobResponseModel()
        {
            Id = job.Id, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), 
            Description = job.Description, NumberOfPositions = job.NumberOfPositions,
            JobCode = job.JobCode
        };
        return jobResponseModel;
    }
    
    public async Task<List<JobResponseModel>> GetJobsByTitle(string title)
    {
        var jobs = await _jobsRepository.GetJobsByTitle(title);
        var models = new List<JobResponseModel>();
        foreach (var job in jobs)
        {
            models.Add(new JobResponseModel()
            {
                Id = job.Id, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), Description = job.Description, NumberOfPositions = job.NumberOfPositions, JobCode = job.JobCode
            });
        }

        return models;
    }

    public async Task<int?> UpdateJob(JobRequestModel model, int id)
    {
        var job = await _jobsRepository.GetJobById(id);
        if (job == null) return null;
        job.Description = model.Description;
        job.JobStatusLookUpId = model.JobStatusLookUpId;
        job.Title = model.Title;
        job.StartDate = model.StartDate;
        job.NumberOfPositions = model.NumberOfPositions;
        var updatedJob = await _jobsRepository.UpdateAsync(job);
        return updatedJob.Id;
    }

    public async Task<int?> DeleteJob(int id)
    {
        var job = await _jobsRepository.GetJobById(id);
        if (job == null) return null;
        await _jobsRepository.DeleteAsync(id);
        return id;
    }

    public async Task<int> AddJob(JobRequestModel model)
    {
        
        //call the repository that will use EF Core to save the data
        var jobEntity = new Job
        {
            Title = model.Title,
            Description = model.Description,
            StartDate = model.StartDate,
            NumberOfPositions = model.NumberOfPositions,
            CreatedOn = DateTime.UtcNow,
            JobStatusLookUpId = model.JobStatusLookUpId,
            JobCode = Guid.NewGuid()
        };
        var job = await _jobsRepository.AddAsync(jobEntity);
        return job.Id;
    }


}