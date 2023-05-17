using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewRequestModel
{
    [Required(ErrorMessage = "Begin Time is required")]
    public DateTime BeginTime { get; set; }
    
    [Required(ErrorMessage = "Candidate id is required")]
    public int CandidateId { get; set; }
    
    [Required(ErrorMessage = "End time is requird")]
    public DateTime EndTime { get; set; }
    
    [StringLength(2048)]
    public string? Feedback { get; set; }
    
    [Required(ErrorMessage = "Interviewer id is required")]
    public int InterviewerId { get; set; }
    
    [Required(ErrorMessage = "Interview type id is required")]
    public int InterviewTypeId { get; set; }
    
    public bool? Passed { get; set; }
    public int? Rating { get; set; }
    
    [Required(ErrorMessage = "Submission id is required")]
    public int SubmissionId { get; set; }

    public string CandidateEmail { get; set; }
    public string CandidateFirstName { get; set; }
    public string CandidateLastName { get; set; }
}