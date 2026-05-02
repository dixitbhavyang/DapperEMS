using DapperEMS.Application.DTOs.Department;
using DapperEMS.Application.DTOs.Employee;
using DapperEMS.Application.Interfaces.Department;
using DapperEMS.Application.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Application.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(CreateDepartmentDto dto)
        {
            return await _departmentRepository.CreateAsync(dto);
        }

        public async Task<bool> UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            return await _departmentRepository.UpdateAsync(id, dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _departmentRepository.DeleteAsync(id);
        }
    }
}
