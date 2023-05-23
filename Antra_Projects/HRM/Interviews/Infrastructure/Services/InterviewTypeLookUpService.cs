using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class InterviewTypeLookUpService: IInterviewTypeLookUpService
{
    private readonly IInterviewTypeLookUpsRepository _interviewTypeLookUpsRepository;

    public InterviewTypeLookUpService(IInterviewTypeLookUpsRepository interviewTypeLookUpsRepository)
    {
        _interviewTypeLookUpsRepository = interviewTypeLookUpsRepository;
    }

    public async Task<InterviewTypeResponseModel> GetInterviewTypeById(int id)
    {
        var interviewType = await _interviewTypeLookUpsRepository.GetByIdAsync(id);
        if (interviewType == null) return null;
        var interviewTypeResponseModel = new InterviewTypeResponseModel()
        {
            Id = interviewType.Id,
            InterviewTypeCode = interviewType.InterviewTypeCode,
            InterviewTypeDescription = interviewType.InterviewTypeDescription
        };
        return interviewTypeResponseModel;
    }

    public async Task<List<InterviewTypeResponseModel>> GetAllTypes()
    {
        var allInterviewTypes = await _interviewTypeLookUpsRepository.GetAllAsync();
        var interviewTypeResponseModels = new List<InterviewTypeResponseModel>();
        foreach (var type in allInterviewTypes)
        {
            interviewTypeResponseModels.Add(new InterviewTypeResponseModel()
            {
                Id = type.Id,
                InterviewTypeCode = type.InterviewTypeCode,
                InterviewTypeDescription = type.InterviewTypeDescription
            });
        }
        return interviewTypeResponseModels;
    }

    public async Task<int> AddInterviewType(InterviewTypeRequestModel model)
    {
        var interviewTypeEntity = new InterviewTypeLookUp()
        {
            InterviewTypeCode = model.InterviewTypeCode,
            InterviewTypeDescription = model.InterviewTypeDescription
        };
        var newInterviewType =  await _interviewTypeLookUpsRepository.AddAsync(interviewTypeEntity);
        return newInterviewType.Id;
    }

    public async Task<int?> DeleteInterviewType(int id)
    {
        var interviewType = await _interviewTypeLookUpsRepository.GetByIdAsync(id);
        if (interviewType != null)
        {
            var interviewTypeId = await _interviewTypeLookUpsRepository.DeleteAsync(id);
            return interviewTypeId;
        }

        return null;
    }

    public async Task<int?> UpdateInterviewType(int id, InterviewTypeRequestModel model)
    {
        var interviewType = await _interviewTypeLookUpsRepository.GetByIdAsync(id);
        if (interviewType != null)
        {
            interviewType.InterviewTypeCode = model.InterviewTypeCode;
            interviewType.InterviewTypeDescription = model.InterviewTypeDescription;
            await _interviewTypeLookUpsRepository.UpdateAsync(interviewType);
            return id;
        }
        return null;
    }
}