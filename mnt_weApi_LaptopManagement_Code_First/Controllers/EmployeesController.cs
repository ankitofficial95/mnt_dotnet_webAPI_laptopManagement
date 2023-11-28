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

        //------------------------------------------------------------------------------------------------------------

        //// GET: api/Employees/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        //{
        //    var employeeDTO = await _employeeService.GetEmployeeById(id);
        //    if (employeeDTO == null)
        //    {
        //        return NotFound("Employee not found for the given ID.");
        //    }

        //    return Ok(employeeDTO);
        //}

        //------------------------------------------------------------------------------------------------------------

        //// PUT: api/Employees/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        //{
        //    var result = await _employeeService.UpdateEmployee(id, employeeDTO);
        //    if (!result)
        //    {
        //        return BadRequest("Failed to update employee.");
        //    }
        //    return NoContent();
        //}

        //------------------------------------------------------------------------------------------------------------

        //// DELETE: api/Employees/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var result = await _employeeService.DeleteEmployee(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
        //------------------------------------------------------------------------------------------------------------
    }
}
