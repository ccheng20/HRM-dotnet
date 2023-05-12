using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    [Required(ErrorMessage = "Please enter Title of the job")]
    [StringLength(256)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter job description")]
    [StringLength(5000)]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Please enter number")]
    public int NumberOfPositions { get; set; }
    
}