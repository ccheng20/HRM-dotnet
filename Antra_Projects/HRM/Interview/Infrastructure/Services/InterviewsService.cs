using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class InterviewsService: IInterviewsService
{
    private readonly IInterviewsRepository _interviewsRepository;

    public InterviewsService(IInterviewsRepository interviewsRepository)
    {
        _interviewsRepository = interviewsRepository;
    }

    public async Task<InterviewResponseModel> GetInterviewById(int id)
    {
        var interview = await _interviewsRepository.GetByIdAsync(id);
        var response = new InterviewResponseModel
        {
            Id = interview.Id,
            InterviewerId = interview.InterviewerId,
            CandidateId = interview.CandidateId,
            Passed = interview.Passed,
            BeginTime = interview.BeginTime,
            CandidateEmail = interview.CandidateEmail,
            CandidateFirstName = interview.CandidateFirstName,
            CandidateLastName = interview.CandidateLastName,
            EndTime = interview.EndTime,
            Feedback = interview.Feedback,
            Rating = interview.Rating,
        };
        return response;
    }

    public async Task<List<InterviewResponseModel>> GetAllInterviews()
    {
        var interviews = await _interviewsRepository.GetAllAsync();
        var response = new List<InterviewResponseModel>();
        foreach (var interview in interviews)
        {
            response.Add(new InterviewResponseModel()
            {
                Id = interview.Id,
                InterviewerId = interview.InterviewerId,
                CandidateId = interview.CandidateId,
                Passed = interview.Passed,
                BeginTime = interview.BeginTime,
                CandidateEmail = interview.CandidateEmail,
                CandidateFirstName = interview.CandidateFirstName,
                CandidateLastName = interview.CandidateLastName,
                EndTime = interview.EndTime,
                Feedback = interview.Feedback,
                Rating = interview.Rating
            });
        }

        return response;
    }

    public async Task<int> AddInterview(InterviewRequestModel model)
    {
     var interview = new Interview()
     {
         InterviewerId = model.InterviewerId,
         BeginTime = model.BeginTime,
         CandidateId = model.CandidateId,
         Passed = model.Passed,
         EndTime = model.EndTime,
         Feedback = model.Feedback,
         CandidateEmail = model.CandidateEmail,
         CandidateFirstName = model.CandidateFirstName, 
         CandidateLastName = model.CandidateLastName,
         Rating = model.Rating
        };
     await _interviewsRepository.AddAsync(interview);
     return interview.Id;
    }

    public async Task<int> DeleteInterview(int id)
    {
        var interview = await _interviewsRepository.GetByIdAsync(id);
        await _interviewsRepository.DeleteAsync(interview.Id);
        return interview.Id;
    }

    public async Task<int> UpdateInterview(InterviewRequestModel model, int id)
    {
        var interview = await _interviewsRepository.GetByIdAsync(id);
        interview.BeginTime = model.BeginTime;
        interview.Feedback = model.Feedback;
        interview.BeginTime = model.BeginTime;
        interview.CandidateEmail = model.CandidateEmail;
        interview.Rating = model.Rating;
        interview.CandidateId = model.CandidateId;
        interview.Passed = model.Passed;
        interview.EndTime = model.EndTime;
        interview.CandidateFirstName = model.CandidateFirstName;
        interview.CandidateLastName = model.CandidateLastName;
        await _interviewsRepository.UpdateAsync(interview);
        return interview.Id;
    }
}