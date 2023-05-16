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

}