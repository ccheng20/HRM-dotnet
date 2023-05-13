using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StatusRepository:Repository<JobStatusLookUp>, IStatusRepository
{
    public StatusRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
    }
}