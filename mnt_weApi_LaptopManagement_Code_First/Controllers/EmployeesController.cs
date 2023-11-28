using Microsoft.AspNetCore.Mvc;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;
using mnt_weApi_LaptopManagement_Code_First.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mnt_weApi_LaptopManagement_Code_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var result = await _employeeService.CreateEmployee(employeeDTO);
            if (!result)
            {
                return BadRequest("Invalid employee data.");
            }
            return Ok("Employee created successfully.");
        }
    }
}
