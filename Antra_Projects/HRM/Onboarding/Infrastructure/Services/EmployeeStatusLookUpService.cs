using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class EmployeeStatusLookUpService: IEmployeeStatusLookUpService
{
    private readonly IEmployeeStatusLookUpRepository _employeeStatusLookUpRepository;

    public EmployeeStatusLookUpService(IEmployeeStatusLookUpRepository employeeStatusLookUpRepository)
    {
        _employeeStatusLookUpRepository = employeeStatusLookUpRepository;
    }

    public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
    {
        var employeeStatus =await _employeeStatusLookUpRepository.GetByIdAsync(id);
        var employeeStatusResponseModel = new EmployeeStatusResponseModel
        {
            Id = employeeStatus.Id,
            EmployeeStatusCode = employeeStatus.EmployeeStatusCode,
            EmployeeStatusDescription = employeeStatus.EmployeeStatusDescription
        };
        return employeeStatusResponseModel;
    }

    public async Task<List<EmployeeStatusResponseModel>> GetAllEmployeeStatusesAsync()
    {
        var employeeStatuses =await _employeeStatusLookUpRepository.GetAllAsync();
        var employeeStatusResponseModels = new List<EmployeeStatusResponseModel>();
        foreach (var employeeStatus in employeeStatuses)
        {
            employeeStatusResponseModels.Add(new EmployeeStatusResponseModel()
            {
                Id = employeeStatus.Id,
                EmployeeStatusCode = employeeStatus.EmployeeStatusCode,
                EmployeeStatusDescription = employeeStatus.EmployeeStatusDescription
            });
        }

        return employeeStatusResponseModels;
    }

    public async Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel employeeStatusRequestModel)
    {
        var employeeStatus = new EmployeeStatusLookUp()
        {
            EmployeeStatusCode = employeeStatusRequestModel.EmployeeStatusCode,
            EmployeeStatusDescription = employeeStatusRequestModel.EmployeeStatusDescription
        };
        await _employeeStatusLookUpRepository.AddAsync(employeeStatus);
        return employeeStatus.Id;
    }

    public async Task UpdateEmployeeStatusAsync(int id, EmployeeStatusRequestModel model)
    {
        var employeeStatus = await _employeeStatusLookUpRepository.GetByIdAsync(id);
        if (employeeStatus != null)
        {
            employeeStatus.EmployeeStatusCode = model.EmployeeStatusCode;
            employeeStatus.EmployeeStatusDescription = model.EmployeeStatusDescription;
            await _employeeStatusLookUpRepository.UpdateAsync(employeeStatus);
        }
    }

    public async Task DeleteEmployeeStatusAsync(int id)
    {
        var employeeStatus = await _employeeStatusLookUpRepository.GetByIdAsync(id);
        if (employeeStatus != null)
        {
            await _employeeStatusLookUpRepository.DeleteAsync(id);
        }
    }
}