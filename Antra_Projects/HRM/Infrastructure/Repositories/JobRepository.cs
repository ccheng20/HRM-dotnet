using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobRepository : IJobsRepository
{
    private RecruitingDbContext _recruitingDbContext;
    public JobRepository(RecruitingDbContext recruitingDbContext)
    {
        _recruitingDbContext = recruitingDbContext;
    }
    public async Task<List<Job>> GetAllJobs()
    {
        // go to database and get the data
        // EF Core with LINQ
        var jobs = await _recruitingDbContext.Jobs.ToListAsync();
        return jobs;
    }

    public async Task<Job> GetJobById(int id)
    {
        var job = await _recruitingDbContext.Jobs.FirstOrDefaultAsync(j=>j.Id == id);
        return job;
    }
}