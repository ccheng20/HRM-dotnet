using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CandidateRepository : Repository<Candidate>, ICandidateRepository
{
    private readonly RecruitingDbContext _recruitingDbContext;

    public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
        _recruitingDbContext = dbContext;
    }
    
    public async Task<Candidate> GetCandidateById(int id)
    {
        var candidate = await _recruitingDbContext.Candidates.FirstOrDefaultAsync(j=>j.Id == id);
        return candidate;
    }

    public async Task<List<Candidate>> GetAllCandidates()
    {
        var candidates = await _recruitingDbContext.Candidates.ToListAsync();
        return candidates;
    }
}