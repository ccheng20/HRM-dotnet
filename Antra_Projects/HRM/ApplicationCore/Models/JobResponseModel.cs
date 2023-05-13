namespace ApplicationCore.Models;

public class JobResponseModel
{
    public int Id { get; set; }
    
    public Guid JobCode { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfPositions { get; set; }
}