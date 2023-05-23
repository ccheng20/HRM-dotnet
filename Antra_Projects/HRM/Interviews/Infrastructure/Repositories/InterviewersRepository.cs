using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InterviewersRepository: Repository<Interviewer>, IInterviewersRepository
{
    private readonly InterviewDbContext _dbContext;
    public InterviewersRepository(InterviewDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<ApplicationCore.Entities.Interview>> GetInterviewsPagination(int pageSize, int pageNumber)
    {
        return await _dbContext.Interviews
            .OrderByDescending(i => i.BeginTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}