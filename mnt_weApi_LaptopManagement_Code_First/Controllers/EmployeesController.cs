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
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employeeDTOs = await _employeeService.GetEmployees();
            return Ok(employeeDTOs);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employeeDTO = await _employeeService.GetEmployeeById(id);
            if (employeeDTO == null)
            {
                return NotFound();
            }

            return Ok(employeeDTO);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            var result = await _employeeService.UpdateEmployee(id, employeeDTO);
            if (!result)
            {
                return BadRequest("Failed to update employee.");
            }

            return NoContent();
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
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
