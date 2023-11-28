using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.DTO;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;
using mnt_weApi_LaptopManagement_Code_First.Services;

namespace mnt_weApi_LaptopManagement_Code_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLaptopMappingsController : ControllerBase
    {
        private readonly IEmployeeLaptopMappingService _employeeLaptopMappingService;

        public EmployeeLaptopMappingsController(IEmployeeLaptopMappingService employeeLaptopMappingService)
        {
            _employeeLaptopMappingService = employeeLaptopMappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeLaptopMapping>>> GetEmployeeLaptopMappings()
        {
            var mappings = await _employeeLaptopMappingService.GetAllMappings();
            return Ok(mappings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeLaptopMapping>> GetMappingById(int id)
        {
            try
            {
                var mapping = await _employeeLaptopMappingService.GetMappingById(id);

                if (mapping == null)
                {
                    return NotFound(); 
                }

                return Ok(mapping); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500); 
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeLaptopMapping(int id, EmployeeLaptopPutDTO employeeLaptopPutDTO)
        {
            var result = await _employeeLaptopMappingService.UpdateMapping(id, employeeLaptopPutDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
       
        
        [HttpPost]
        public async Task<IActionResult> CreateMapping([FromBody] EmployeeLaptopDTO employeeLaptopDTO)

        {
            try
            {
                var result = await _employeeLaptopMappingService.CreateMapping(employeeLaptopDTO);
                if (!result)
                {
                    return BadRequest(); 
                }
                return Ok("mapping created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeLaptopMapping(int id)
        {
            var result = await _employeeLaptopMappingService.DeleteMapping(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
