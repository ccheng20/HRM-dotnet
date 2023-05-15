using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ICandidateRepository: IRepository<Candidate>
{
    Task<Candidate> GetCandidateById(int id);
    Task<List<Candidate>> GetAllCandidates();
}