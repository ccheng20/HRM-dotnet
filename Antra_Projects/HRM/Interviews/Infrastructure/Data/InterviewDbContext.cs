

using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InterviewDbContext: DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options){}
    public DbSet<ApplicationCore.Entities.Interview> Interviews { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
}