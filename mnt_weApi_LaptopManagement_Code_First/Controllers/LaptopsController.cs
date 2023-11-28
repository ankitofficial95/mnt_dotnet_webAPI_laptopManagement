using Microsoft.AspNetCore.Http;
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
    public class LaptopsController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        public LaptopsController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        [HttpGet]
        // GET: api/laptops
        public async Task<ActionResult<IEnumerable<Laptop>>> GetLaptops()
        {
            var laptops = await _laptopService.GetLaptops();
            return Ok(laptops);
        }

        [HttpGet("id")]
        // GET: api/latops/4
        public async Task<ActionResult<LaptopDTO>> GetLaptop(int id)
        {
            var laptopDTO = await _laptopService.GetLaptopById(id);
            if (laptopDTO == null)
            {
                return NotFound();
            }
            return Ok(laptopDTO);
        }

        // PUT: api/laptops/4
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptop (int id, [FromBody] LaptopPutDto laptopPutDto)
        {
            var result = await _laptopService.UpdateLaptop(id, laptopPutDto);
            if (!result)
            {
                return BadRequest("Failed to update laptop.");
            }
            return Ok("laptop update done !!!");
        }


        //Post : api/laptops
        [HttpPost]
        public async Task<IActionResult> CreateLaptop([FromBody] LaptopDTO laptopDTO)
        {
            var result = await _laptopService.CreateLaptop(laptopDTO);
            if (!result)
            {
                return BadRequest("Invalid laptop data.");
            }
            return Ok("laptop created successfully.");
        }

        // DELETE: api/laptops/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var result = await _laptopService.DeleteLaptop(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("deleted done !!!!!!!");
        }
    }
}
