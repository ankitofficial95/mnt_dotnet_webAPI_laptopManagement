using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Services;
using YourNamespace.DTOs;

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

        //[HttpGet]
        //public async Task<IActionResult> GetAllMappings()
        //{
        //    var mappings = await _employeeLaptopMappingService.GetAllMappings();
        //    return Ok(mappings);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMappingById(int id)
        //{
        //    var mapping = await _employeeLaptopMappingService.GetMappingById(id);
        //    if (mapping == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(mapping);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateMapping([FromBody] EmployeeLaptopMappingDTO mappingDTO)
        {
            try
            {
                var success = await _employeeLaptopMappingService.CreateMapping(mappingDTO);
                if (success)
                {
                    return Ok("Mapping created successfully.");
                }
                else
                {
                    return BadRequest("Failed to create mapping.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMapping(int id, EmployeeLaptopMappingDTO mappingDTO)
        {
            var result = await _employeeLaptopMappingService.UpdateMapping(id, mappingDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMapping(int id)
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
