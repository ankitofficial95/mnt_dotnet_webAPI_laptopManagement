using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.DTOs;

namespace YourNamespace.Services
{
    public interface IEmployeeLaptopMappingService
    {
        Task<IEnumerable<EmployeeLaptopMappingDTO>> GetAllMappings();
        Task<EmployeeLaptopMappingDTO> GetMappingById(int id);
        Task<EmployeeLaptopMappingDTO> CreateMapping(EmployeeLaptopMappingDTO mappingDTO);
        Task<bool> UpdateMapping(int id, EmployeeLaptopMappingDTO mappingDTO);
        Task<bool> DeleteMapping(int id);
    }
}
