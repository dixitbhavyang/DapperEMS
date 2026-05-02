using DapperEMS.Application.DTOs.Department;
using DapperEMS.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Application.Interfaces.Department
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateDepartmentDto dto);
        Task<bool> UpdateAsync(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
