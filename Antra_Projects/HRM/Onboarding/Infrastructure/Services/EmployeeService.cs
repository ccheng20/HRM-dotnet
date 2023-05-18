using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null)
        {
            return null;
        }

        var employeeResponseModel = new EmployeeResponseModel()
        {
            Id = employee.Id,
            Address = employee.Address,
            Email = employee.Email,
            EmployeeIdentityId = employee.EmployeeIdentityId,
            EmployeeStatusId = employee.EmployeeStatusId,
            EndDate = employee.EndDate,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            HireDate = employee.HireDate,
            MiddleName = employee.MiddleName,
            SSN = employee.SSN
        };
        return employeeResponseModel;
    }

    public async Task<List<EmployeeResponseModel>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        var employeeResponseModels = new List<EmployeeResponseModel>();
        foreach (var employee in employees)
        {
            employeeResponseModels.Add(new EmployeeResponseModel()
            {
                Id = employee.Id,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeIdentityId = employee.EmployeeIdentityId,
                EmployeeStatusId = employee.EmployeeStatusId,
                EndDate = employee.EndDate,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN
            });
        }

        return employeeResponseModels;
    }

    public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
    {
        var employeeEntity = new Employees()
        {
            Address = model.Address,
            Email = model.Email,
            EmployeeIdentityId = model.EmployeeIdentityId,
            EmployeeStatusId = model.EmployeeStatusId,
            EndDate = model.EndDate,
            FirstName = model.FirstName,
            LastName = model.LastName,
            HireDate = model.HireDate,
            MiddleName = model.MiddleName,
            SSN = model.SSN
        };
        await _employeeRepository.AddAsync(employeeEntity);
        return employeeEntity.Id;
    }

    public async Task UpdateEmployeeAsync(int id, EmployeeRequestModel model)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee != null)
        {
            employee.Address = model.Address;
            employee.Email = model.Email;
            employee.EmployeeIdentityId = model.EmployeeIdentityId;
            employee.EmployeeStatusId = model.EmployeeStatusId;
            employee.EndDate = model.EndDate;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.HireDate = model.HireDate;
            employee.MiddleName = model.MiddleName;
            employee.SSN = model.SSN;
            await _employeeRepository.UpdateAsync(employee);
        }
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee != null)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}