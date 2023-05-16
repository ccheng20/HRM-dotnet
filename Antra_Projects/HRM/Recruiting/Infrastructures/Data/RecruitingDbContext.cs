using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary1.Data;

public class RecruitingDbContext: DbContext
{
    
    public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options): base(options)
    {
        
    }
    //DbSet are properties of DbContext
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I can use this method to do Fluent API way to do any schema changes just like data annotation
        modelBuilder.Entity<Candidate>(ConfigureCandidate);
    }

    private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
    {
        // we can establish the rules for candidate table
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
    }
}