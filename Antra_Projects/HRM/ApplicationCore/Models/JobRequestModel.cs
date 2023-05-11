namespace ApplicationCore.Models;

public class JobRequestModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfPositions { get; set; }
    
}