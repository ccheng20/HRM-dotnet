

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ClassLibrary1.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ISubmissionRepository _submissionRepository;

    public CandidateService(ICandidateRepository candidateRepository, ISubmissionRepository submissionRepository)
    {
        _candidateRepository = candidateRepository;
        _submissionRepository = submissionRepository;
    }

    public async Task<CandidateResponseModel> GetCandidateById(int id)
    {
        var candidate = await _candidateRepository.GetCandidateById(id);
        if (candidate == null)
        {
            return null;
        }
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



    public async Task<int> UpdateCandidate(CandidateRequestModel model, int id)
    {
        var existingCandidate = await _candidateRepository.GetCandidateById(id);
        if (existingCandidate != null)
        {
            existingCandidate.Email = model.Email;
            existingCandidate.FirstName = model.FirstName;
            existingCandidate.LastName = model.LastName;
            existingCandidate.Submissions = await _submissionRepository.GetSubmissionsByCandidate(id);
            existingCandidate.ResumeURL = model.ResumeURL;
        }

        var candidateId = await _candidateRepository.UpdateAsync(existingCandidate);
        return candidateId;
    }
}