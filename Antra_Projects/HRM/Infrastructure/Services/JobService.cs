using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

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
                Id= job.Id, Description = job.Description, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), NumberOfPositions = job.NumberOfPositions
            });
        }

        return jobsResponseModel;
    }

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobsRepository.GetJobById(id);
        var jobResponseModel = new JobResponseModel()
        {
            Id = job.Id, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault(), Description = job.Description
        };
        return jobResponseModel;
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
            JobStatusLookUpId = 1
        };
        var job = await _jobsRepository.AddAsync(jobEntity);
        return job.Id;
    }
}