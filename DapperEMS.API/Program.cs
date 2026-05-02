using DapperEMS.Application.Interfaces.Department;
using DapperEMS.Application.Interfaces.Employee;
using DapperEMS.Application.Services.Department;
using DapperEMS.Application.Services.Employee;
using DapperEMS.Infrastructure.Data;
using DapperEMS.Infrastructure.Repositories.Department;
using DapperEMS.Infrastructure.Repositories.Employee;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();