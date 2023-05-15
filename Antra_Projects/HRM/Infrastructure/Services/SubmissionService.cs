using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class SubmissionService:ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public Task<SubmissionResponseModel> GetSubmissionById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddSubmission(SubmissionRequestModel model)
    {
        var submissionEntity = new Submission()
        {
            CandidateId = 1, JobId = model.jobModel.Id, SubmittedOn = DateTime.UtcNow
        };
        var submission = await _submissionRepository.AddAsync(submissionEntity);
        return submission.Id;
    }
}