using Dapper;
using DapperEMS.Application.DTOs;
using DapperEMS.Application.Interfaces;
using DapperEMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var sql = @"
            SELECT e.Id, e.Name, e.Email, e.Salary, d.Name AS DepartmentName
            FROM Employees e
            INNER JOIN Departments d ON e.DepartmentId = d.Id";

            using var connection = _context.CreateConnection();

            var employees = await connection.QueryAsync<EmployeeDto>(sql);
            return employees;
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var sql = @"
            SELECT e.Id, e.Name, e.Email, e.Salary, d.Name AS DepartmentName
            FROM Employees e
            INNER JOIN Departments d ON e.DepartmentId = d.Id
            WHERE e.Id = @Id";

            using var connection = _context.CreateConnection();

            var employee = await connection.QueryFirstOrDefaultAsync<EmployeeDto>(sql, new { Id = id });
            return employee;
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var sql = @"
            INSERT INTO Employees (Name, Email, Salary, DepartmentId)
            VALUES (@Name, @Email, @Salary, @DepartmentId);
            SELECT CAST(SCOPE_IDENTITY() AS int);";

            using var connection = _context.CreateConnection();

            var newId = await connection.ExecuteScalarAsync<int>(sql, dto);
            return newId;
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var sql = @"
            UPDATE Employees
            SET Name = @Name, Email = @Email, Salary = @Salary, DepartmentId = @DepartmentId
            WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                dto.Name,
                dto.Email,
                dto.Salary,
                dto.DepartmentId,
                Id = id
            });

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
