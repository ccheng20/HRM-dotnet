using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InterviewsRepository: Repository<ApplicationCore.Entities.Interview>, IInterviewsRepository
{
    public InterviewsRepository(InterviewDbContext dbContext) : base(dbContext)
    {
    }
}