using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
{
    public Task<Submission> GetSubmissionById(int id)
    {
        throw new NotImplementedException();
    }

    public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
    }
}