using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class EmployeeStatusLookUpRepository: BaseRepository<EmployeeStatusLookUp>, IEmployeeStatusLookUpRepository
{
    public EmployeeStatusLookUpRepository(OnboardingDbContext dbContext) : base(dbContext)
    {
    }
}