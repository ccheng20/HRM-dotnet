using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InterviewsRepository: Repository<Interview>, IInterviewsRepository
{
    public InterviewsRepository(InterviewDbContext dbContext) : base(dbContext)
    {
    }
}