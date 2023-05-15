using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class CandidateRequestModel
{
    [Required(ErrorMessage = "Please enter your firstname")]
    [StringLength(216)]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Please enter your last name")]
    [StringLength(216)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your email properly")]
    [StringLength(1000)]
    public string Email { get; set; }

    public string? ResumeURL { get; set; }

    public DateTime CreatedOn { get; set; }
    
}