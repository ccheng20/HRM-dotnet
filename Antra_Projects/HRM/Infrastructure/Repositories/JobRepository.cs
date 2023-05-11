using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class JobRepository : IJobsRepository
{
    private RecruitingDbContext _recruitingDbContext;
    public JobRepository(RecruitingDbContext recruitingDbContext)
    {
        _recruitingDbContext = recruitingDbContext;
    }
    public List<Job> GetAllJobs()
    {
        // go to database and get the data
        // EF Core with LINQ
        var jobs = _recruitingDbContext.Jobs.ToList();
        return jobs;
    }
}