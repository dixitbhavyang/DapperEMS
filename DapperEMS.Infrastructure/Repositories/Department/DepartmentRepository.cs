using Dapper;
using DapperEMS.Application.DTOs.Department;
using DapperEMS.Application.Interfaces.Department;
using DapperEMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Infrastructure.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var sql = @"
            SELECT d.Id, d.Name
            FROM Departments d";

            using var connection = _context.CreateConnection();

            var departments = await connection.QueryAsync<DepartmentDto>(sql);
            return departments;
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var sql = @"
            SELECT d.Id, d.Name
            FROM Departments d
            WHERE d.Id = @Id";

            using var connection = _context.CreateConnection();

            var employee = await connection.QueryFirstOrDefaultAsync<DepartmentDto>(sql, new { Id = id });
            return employee;
        }

        public async Task<int> CreateAsync(CreateDepartmentDto dto)
        {
            var sql = @"
            INSERT INTO Departments (Name)
            VALUES (@Name);
            SELECT CAST(SCOPE_IDENTITY() AS int);";

            using var connection = _context.CreateConnection();

            var newId = await connection.ExecuteScalarAsync<int>(sql, dto);
            return newId;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            var sql = @"
            UPDATE Departments
            SET Name = @Name
            WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                dto.Name,
                Id = id
            });

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Departments WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
