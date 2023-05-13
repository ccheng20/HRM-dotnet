using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    [Required(ErrorMessage = "Email is required")]
    [StringLength(256)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [StringLength(256)]
    public string? ResumeUrl { get; set; }
}