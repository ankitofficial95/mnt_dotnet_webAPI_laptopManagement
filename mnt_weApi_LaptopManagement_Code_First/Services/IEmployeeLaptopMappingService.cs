using mnt_weApi_LaptopManagement_Code_First.DTO;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public interface IEmployeeLaptopMappingService
    {
        Task<IEnumerable<EmployeeLaptopMapping>> GetAllMappings();
        Task<EmployeeLaptopMapping> GetMappingById(int id);
        Task<bool> CreateMapping(EmployeeLaptopDTO employeeLaptopDTO);
        Task<bool> UpdateMapping(int id, EmployeeLaptopPutDTO employeeLaptopPutDTO);
        Task<bool> DeleteMapping(int id);
    }
}
