namespace Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;
public class InterviewDbContext: DbContext
{
    public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options){}
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
}