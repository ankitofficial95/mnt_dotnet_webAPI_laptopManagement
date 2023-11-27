using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.DTOs;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLaptopMappingsController : ControllerBase
    {
        private readonly IEmployeeLaptopMappingService _mappingService;

        public EmployeeLaptopMappingsController(IEmployeeLaptopMappingService mappingService)
        {
            _mappingService = mappingService;
        }
    }
}
