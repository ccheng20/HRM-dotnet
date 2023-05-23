using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewerRequestModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public int EmployeeIdentityId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}