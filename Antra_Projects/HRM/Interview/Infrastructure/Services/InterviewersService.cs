using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class InterviewersService: IInterviewersService
{
    private readonly IInterviewersRepository _interviewersRepository;

    public InterviewersService(IInterviewersRepository interviewersRepository)
    {
        _interviewersRepository = interviewersRepository;
    }

    public async Task<InterviewerResponseModel> GetInterviewerById(int id)
    {
        var interviewer = await _interviewersRepository.GetByIdAsync(id);
        var response = new InterviewerResponseModel
        {
            Id = interviewer.Id,
            Email = interviewer.Email,
            FirstName = interviewer.FirstName,
            LastName = interviewer.LastName,
            EmployeeIdentityId = interviewer.EmployeeIdentityId
        };
        return response;
    }

    public async Task<List<InterviewerResponseModel>> GetAllInterviewers()
    {
        var interviewers = await _interviewersRepository.GetAllAsync();
        var response = new List<InterviewerResponseModel>();
        foreach (var interview in interviewers)
        {
            response.Add(new InterviewerResponseModel()
            {
                Id = interview.Id,
                Email = interview.Email,
                EmployeeIdentityId = interview.EmployeeIdentityId,
                FirstName = interview.FirstName,
                LastName = interview.LastName,
            });
        }

        return response;
    }

    public async Task<int> AddInterviewer(InterviewerRequestModel model)
    {
        var interviewer = new Interviewer()
        {
            Email = model.Email,
            EmployeeIdentityId = model.EmployeeIdentityId,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        await _interviewersRepository.AddAsync(interviewer);
        return interviewer.Id;
    }

    public async Task<int?> DeleteInterviewer(int id)
    {
        var interviewer = await _interviewersRepository.GetByIdAsync(id);
        if (interviewer == null) return null;
        await _interviewersRepository.DeleteAsync(id);
        return interviewer.Id;
    }

    public async Task<int?> UpdateInterviewer(int id, InterviewerRequestModel model)
    {
        var interviewer = await _interviewersRepository.GetByIdAsync(id);
        if (interviewer == null) return null;
        interviewer.Email = model.Email;
        interviewer.EmployeeIdentityId = model.EmployeeIdentityId;
        interviewer.FirstName = model.FirstName;
        interviewer.LastName = model.LastName;
        await _interviewersRepository.UpdateAsync(interviewer);
        return interviewer.Id;
    }
}