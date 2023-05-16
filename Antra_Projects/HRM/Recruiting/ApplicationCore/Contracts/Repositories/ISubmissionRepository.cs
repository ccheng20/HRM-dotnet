using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository: IRepository<Submission>
{
    Task<Submission> GetSubmissionById(int id);
    Task<List<Submission>> GetAllSubmission();
    Task<List<Submission>> GetSubmissionsByCandidate(int candidateId);
    Task<List<Submission>> GetSubmissionsByJob(int jobId);
}