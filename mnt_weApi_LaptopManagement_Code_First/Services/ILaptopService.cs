using mnt_weApi_LaptopManagement_Code_First.DTO;
using mnt_weApi_LaptopManagement_Code_First.Model;
using System.ComponentModel.DataAnnotations;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public interface ILaptopService
    {
        Task <IEnumerable<Laptop>> GetLaptops();
        Task<Laptop> GetLaptopById(int id);
        Task<bool> UpdateLaptop(int id,  LaptopPutDto laptopUpdateDTO);
        Task<bool> DeleteLaptop(int id);
        Task<bool> CreateLaptop(LaptopDTO laptopDTO);
    }
}
