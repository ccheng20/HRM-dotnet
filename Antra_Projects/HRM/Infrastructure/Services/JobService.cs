using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IJobsRepository _jobsRepository;
    public JobService(IJobsRepository jobsRepository)
    {
        _jobsRepository = jobsRepository;
    }
    public List<JobResponseModel> GetAllJobs()
    {
        var jobs = _jobsRepository.GetAllJobs();
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

    public JobResponseModel GetJobById(int id)
    {
        return new JobResponseModel
        {
            Id = 3, Title = "Python Developer", Description = "Need to be good with Python"
        };
    }
}