using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class EmployeeStatusRequestModel
{
    [Required]
    [StringLength(64)]
    public string EmployeeStatusCode { get; set; }
    [Required]
    [StringLength(1024)]
    public string EmployeeStatusDescription { get; set; }
}