using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class EmployeeRequestModel
{
    public string? Address { get; set; }
    [StringLength(2048)]
    [Required]
    public string Email { get; set; }
    [Required]
    public int EmployeeIdentityId { get; set; }
    [Required]
    public int EmployeeStatusId { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    public DateTime? HireDate { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string? MiddleName { get; set; }
    [Required]
    [StringLength(2048)]
    public string SSN { get; set; }
}