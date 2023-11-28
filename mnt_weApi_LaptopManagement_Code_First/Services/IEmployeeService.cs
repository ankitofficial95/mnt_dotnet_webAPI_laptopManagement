using System.Collections.Generic;
using System.Threading.Tasks;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<bool> UpdateEmployee(int id, EmployeeDTO employeeDTO);
        Task<bool> CreateEmployee(EmployeeDTO employeeDTO);
        Task<bool> DeleteEmployee(int id);
    }
}
