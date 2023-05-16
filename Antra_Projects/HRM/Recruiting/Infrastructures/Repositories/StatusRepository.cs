using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ClassLibrary1.Data;

namespace ClassLibrary1.Repositories;

public class StatusRepository:Repository<JobStatusLookUp>, IStatusRepository
{
    public StatusRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
    }
}