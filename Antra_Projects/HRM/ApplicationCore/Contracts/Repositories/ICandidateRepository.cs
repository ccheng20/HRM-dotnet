using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ICandidateRepository
{
    Task<Candidate> GetCandidateById(int id);
}