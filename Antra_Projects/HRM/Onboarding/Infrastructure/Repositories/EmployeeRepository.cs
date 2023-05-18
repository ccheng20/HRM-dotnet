using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class EmployeeRepository: BaseRepository<Employees>, IEmployeeRepository
{
    public EmployeeRepository(OnboardingDbContext dbContext) : base(dbContext)
    {
    }
}