using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Service;

public interface IInterviewTypeLookUpService
{
    Task<InterviewTypeResponseModel> GetInterviewTypeById(int id);
    Task<List<InterviewTypeResponseModel>> GetAllTypes();
    Task<int> AddInterviewType(InterviewTypeRequestModel model);
    Task<int?> DeleteInterviewType(int id);
    Task<int?> UpdateInterviewType(int id, InterviewTypeRequestModel model);
}