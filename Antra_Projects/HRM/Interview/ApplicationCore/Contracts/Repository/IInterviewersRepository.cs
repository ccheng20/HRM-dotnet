using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IInterviewersRepository: IRepository<Interviewer>
{
    Task<IEnumerable<Interview>> GetInterviewsPagination(int pageSize, int pageNumber);
}