using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Job
{
    public int Id { get; set; }
    public Guid JobCode { get; set; }
    
    [MaxLength(80)]
    public string Title { get; set; }
    
    [MaxLength(2048)]
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? IsActive { get; set; }
    public int NumberOfPositions { get; set; }
    public DateTime? ClosedOn { get; set; }
    
    [MaxLength(2048)]
    public string? ClosedReason { get; set; }
    public DateTime? CreatedOn { get; set; }
    

    // add FK
    public int JobStatusLookUpId { get; set; }
    // navigation property in EF - navigating from one table to another table
    public JobStatusLookUp JobStatusLookUp { get; set; }
    
    public List<Submission> Submissions { get; set; }
}