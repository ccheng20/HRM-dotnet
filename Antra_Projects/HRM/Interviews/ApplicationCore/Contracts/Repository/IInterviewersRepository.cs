using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IInterviewersRepository: IRepository<Interviewer>
{
    Task<IEnumerable<Entities.Interview>> GetInterviewsPagination(int pageSize, int pageNumber);
}