using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Service;

public interface IInterviewersService
{
    Task<InterviewerResponseModel> GetInterviewerById(int id);
    Task<List<InterviewerResponseModel>> GetAllInterviewers();
    Task<int> AddInterviewer(InterviewerRequestModel model);
    Task<int?> DeleteInterviewer(int id);
    Task<int?> UpdateInterviewer(int id, InterviewerRequestModel model);
}