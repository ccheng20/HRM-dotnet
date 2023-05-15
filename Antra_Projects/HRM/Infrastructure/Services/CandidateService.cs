using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public async Task<CandidateResponseModel> GetCandidateById(int id)
    {
        var candidate = await _candidateRepository.GetCandidateById(id);

        var candidateResponseModel = new CandidateResponseModel()
        {
            Id = candidate.Id, CreatedOn = candidate.CreatedOn, Email = candidate.Email,
            FirstName = candidate.FirstName,
            LastName = candidate.LastName, MiddleName = candidate.MiddleName, ResumeURL = candidate.ResumeURL,
            Submissions = candidate.Submissions
        };
        return candidateResponseModel;
    }

    public async Task<List<CandidateResponseModel>> GetAllCandidates()
    {
        var candidates = await _candidateRepository.GetAllCandidates();
        var models = new List<CandidateResponseModel>();
        foreach (var candidate in candidates)
        {
            models.Add(new CandidateResponseModel()
            {
                Id = candidate.Id, CreatedOn = candidate.CreatedOn, Email = candidate.Email, FirstName = candidate.FirstName, 
                LastName = candidate.LastName, MiddleName = candidate.MiddleName, ResumeURL = candidate.ResumeURL, Submissions = candidate.Submissions
            });
        }

        return models;
    }

    public async Task<int> AddCandidate(CandidateRequestModel model)
    {
        var candidateEntity = new Candidate()
        {
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            Email = model.Email,
            ResumeURL = model.ResumeURL,
            CreatedOn = DateTime.UtcNow,
        };
        var candidate =await _candidateRepository.AddAsync(candidateEntity);
        return candidate.Id;
    }
}