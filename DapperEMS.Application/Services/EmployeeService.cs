using DapperEMS.Application.DTOs;
using DapperEMS.Application.Interfaces;

namespace DapperEMS.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(CreateEmployeeDto dto)
    {
        return await _employeeRepository.CreateAsync(dto);
    }

    public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto)
    {
        return await _employeeRepository.UpdateAsync(id, dto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _employeeRepository.DeleteAsync(id);
    }
}