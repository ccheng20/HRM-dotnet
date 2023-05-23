using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Service;

public interface IInterviewsService
{
    Task<InterviewResponseModel> GetInterviewById(int id);
    Task<List<InterviewResponseModel>> GetAllInterviews();
    Task<int> AddInterview(InterviewRequestModel model);
    Task<int> DeleteInterview(int id);
    Task<int> UpdateInterview(InterviewRequestModel model, int id);
}

