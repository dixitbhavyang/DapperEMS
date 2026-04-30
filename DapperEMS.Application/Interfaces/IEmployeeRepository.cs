using DapperEMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
