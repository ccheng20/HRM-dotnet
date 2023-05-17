using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICandidateService
{
    Task<CandidateResponseModel> GetCandidateById(int id);
    Task<List<CandidateResponseModel>> GetAllCandidates();
    Task<int> AddCandidate(CandidateRequestModel model);

    Task<int> UpdateCandidate(CandidateRequestModel model, int id);
    Task<int?> DeleteCandidate(int id);
}