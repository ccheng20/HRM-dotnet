using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OnboardingDbContext: DbContext
{
    public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options):base(options){}
    public DbSet<Employees> Employees { get; set; }
    public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }
}