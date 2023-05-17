using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    Task<SubmissionResponseModel> GetSubmissionById(int id);
    Task<int> AddSubmission(SubmissionRequestModel model);

    Task<List<SubmissionResponseModel>> GetSubmissionsByCandidateId(int candidateId);
    Task<List<SubmissionResponseModel>> GetSubmissionsByJobId(int jobId);
    Task<List<SubmissionResponseModel>> GetAllSubmissions();

    Task<int> DeleteSubmission(int id);
    Task<int> UpdateSubmission(SubmissionRequestModel model, int id);

}