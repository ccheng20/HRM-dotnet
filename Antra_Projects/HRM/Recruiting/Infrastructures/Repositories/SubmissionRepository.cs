using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ClassLibrary1.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Repositories;

public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
{
    private readonly RecruitingDbContext _recruitingDbContext;
    public async Task<Submission> GetSubmissionById(int id)
    {
        var submission = await _recruitingDbContext.Submissions.FirstOrDefaultAsync(s => s.Id == id);
        return submission;
    }

    public async Task<List<Submission>> GetAllSubmission()
    {
        var submissions = await _recruitingDbContext.Submissions.ToListAsync();
        return submissions;
    }

    public async Task<List<Submission>> GetSubmissionsByCandidate(int candidateId)
    {
        var submissions = await _recruitingDbContext.Submissions.Where(s => s.CandidateId == candidateId).ToListAsync();
        return submissions;
    }

    public async Task<List<Submission>> GetSubmissionsByJob(int jobId)
    {
        var submissions = await _recruitingDbContext.Submissions.Where(s => s.JobId == jobId).ToListAsync();
        return submissions;
    }

    public SubmissionRepository(RecruitingDbContext dbContext, RecruitingDbContext recruitingDbContext) : base(dbContext)
    {
        _recruitingDbContext = recruitingDbContext;
    }
}