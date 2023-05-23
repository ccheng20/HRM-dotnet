using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InterviewTypeLookUpsRepository: Repository<InterviewTypeLookUp>, IInterviewTypeLookUpsRepository
{
    public InterviewTypeLookUpsRepository(InterviewDbContext dbContext) : base(dbContext)
    {
    }
}