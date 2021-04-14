using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.API.Filters;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Domain;
using EmployeeManagement.API.Models;
using Database.Employee.Persistence.EFCore;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [HandleApiErrors]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(IUnitOfWork unitOfWork, EmployeeDbContext employeeDbContext)
        {
            _unitOfWork = unitOfWork;
            _employeeDbContext = employeeDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> PostDepartments([FromBody] List<DepartmentModel> departmentModels)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var departments = new List<Department>();
            try
            {
                foreach (var departmentModel in departmentModels)
                {
                    departments.Add(new Department
                    {
                        DepartmentPId = departmentModel.DepartmentPId,
                        DepartmentName = departmentModel.DepartmentName
                    });
                }
                await _unitOfWork.Department.AddRangeAsync(departments);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployees([FromBody] List<EmployeeModel> employeeModels)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var employees = new List<Employee>();
            try
            {
                var departments = await _unitOfWork.Department.GetAllAsync();
                var lastDepartmentId = departments.ToList().Max(x => x.DepartmentPId);
                foreach (var employeeModel in employeeModels)
                {
                    employees.Add(new Employee
                    {
                        EmployeePId = employeeModel.EmployeePId,
                        Department = departments.FirstOrDefault(x => x.DepartmentUid == employeeModel.DepartmentId) ??
                            new Department { DepartmentPId = ++lastDepartmentId, DepartmentName = employeeModel.DepartmentName },
                        Age = employeeModel.Age,
                        FirstName = employeeModel.FirstName,
                        LastName = employeeModel.LastName,
                    });
                }
                await _unitOfWork.Employee.AddRangeAsync(employees);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }
    }
}
