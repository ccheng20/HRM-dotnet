using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeStatusLookUpService
{
    Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
    Task<List<EmployeeStatusResponseModel>> GetAllEmployeeStatusesAsync();
    Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel employeeStatusRequestModel);
    Task UpdateEmployeeStatusAsync(int id, EmployeeStatusRequestModel employeeStatusRequestModel);
    Task DeleteEmployeeStatusAsync(int id);
}