using System;
using System.Collections.Generic;
using System.Text;

namespace DapperEMS.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
