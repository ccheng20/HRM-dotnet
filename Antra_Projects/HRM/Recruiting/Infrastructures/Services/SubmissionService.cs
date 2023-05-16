

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ClassLibrary1.Services;

public class SubmissionService:ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public async Task<SubmissionResponseModel> GetSubmissionById(int id)
    {
        var submission = await _submissionRepository.GetSubmissionById(id);
        var submissionModel = new SubmissionResponseModel()
        {
            Id = submission.Id,
            CandidateId = submission.CandidateId,
            JobId = submission.JobId,
            RejectedOn = submission.RejectedOn,
            RejectedReason = submission.RejectedReason,
            SelectedForInterview = submission.SelectedForInterview,
            SubmittedOn = submission.SubmittedOn
        };
        return submissionModel;
    }

    public async Task<int> AddSubmission(SubmissionRequestModel model)
    {
        var submissionEntity = new Submission()
        {
            CandidateId = model.CandidateId, JobId = model.JobId, SubmittedOn = DateTime.UtcNow,
        };
        var submission = await _submissionRepository.AddAsync(submissionEntity);
        return submission.Id;
    }

    public async Task<List<SubmissionResponseModel>> GetSubmissionsByCandidateId(int candidateId)
    {
        var submissionModels = new List<SubmissionResponseModel>();
        var submissions =await _submissionRepository.GetSubmissionsByCandidate(candidateId);
        foreach (var submission in submissions)
        {
            submissionModels.Add(new SubmissionResponseModel()
            {
                CandidateId = candidateId,
                Id = submission.Id,
                JobId = submission.JobId,
                RejectedOn = submission.RejectedOn,
                RejectedReason = submission.RejectedReason,
                SelectedForInterview = submission.SelectedForInterview,
                SubmittedOn = submission.SubmittedOn
            });
        }

        return submissionModels;
    }

    public async Task<List<SubmissionResponseModel>> GetSubmissionsByJobId(int jobId)
    {
        var submissionModel = new List<SubmissionResponseModel>();
        var submissions = await _submissionRepository.GetSubmissionsByJob(jobId);
        foreach (var submission in submissions)
        {
            submissionModel.Add(new SubmissionResponseModel()
            {
                CandidateId = submission.JobId,
                Id = submission.Id,
                JobId = submission.JobId,
                RejectedOn = submission.RejectedOn,
                RejectedReason = submission.RejectedReason,
                SelectedForInterview = submission.SelectedForInterview,
                SubmittedOn = submission.SubmittedOn
            });
        }

        return submissionModel;
    }

    public async Task<List<SubmissionResponseModel>> GetAllSubmissions()
    {
        var submissions = await _submissionRepository.GetAllSubmission();
        var submissionModels = new List<SubmissionResponseModel>();
        foreach (var submission in submissions)
        {
            submissionModels.Add(new SubmissionResponseModel()
            {
                CandidateId = submission.JobId,
                Id = submission.Id,
                JobId = submission.JobId,
                RejectedOn = submission.RejectedOn,
                RejectedReason = submission.RejectedReason,
                SelectedForInterview = submission.SelectedForInterview,
                SubmittedOn = submission.SubmittedOn
            });
        }

        return submissionModels;
    }
}