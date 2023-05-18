using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeService
{
    Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    Task<List<EmployeeResponseModel>> GetAllEmployeesAsync();
    Task<int> AddEmployeeAsync(EmployeeRequestModel employeeRequestModel);
    Task UpdateEmployeeAsync(int id, EmployeeRequestModel employeeRequestModel);
    Task DeleteEmployeeAsync(int id);
}