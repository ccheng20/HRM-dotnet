using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ISubmissionRepository: IRepository<Submission>
{
    Task<Submission> GetSubmissionById(int id);
}