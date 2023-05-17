using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewTypeRequestModel
{
    [Required]
    public string InterviewTypeCode { get; set; }
    [Required]
    public string InterviewTypeDescription { get; set; }
}