using System.Collections.Generic;
using System.Threading.Tasks;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using YourNamespace.DTOs;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public interface IEmployeeLaptopMappingService
    {
        Task<bool> CreateMapping(EmployeeLaptopMappingDTO mappingDTO);
        Task<bool> DeleteMapping(int id);
       // Task<IEnumerable<EmployeeLaptopMappingDTO>> GetAllMappings();
      //  Task<EmployeeLaptopMappingDTO> GetMappingById(int id);
        Task<bool> UpdateMapping(int id, EmployeeLaptopMappingDTO mappingDTO);
    }
}
