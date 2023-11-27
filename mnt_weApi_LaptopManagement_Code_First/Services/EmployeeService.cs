using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly mntContext _context;
        public EmployeeService(mntContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var employeeDTOs = employees.Select(employee => new EmployeeDTO
            {
                EmpName = employee.empname,
                IsLaptopAssigned = employee.isLaptopAssigned
            }).ToList();
            return employeeDTOs;
        }
        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            var employeeDTO = new EmployeeDTO
            {
                EmpName = employee.empname,
                IsLaptopAssigned = employee.isLaptopAssigned
            };

            return employeeDTO;
        }
        public async Task<bool> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }
            employee.empname = employeeDTO.EmpName;
            employee.isLaptopAssigned = employeeDTO.IsLaptopAssigned;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return false; 
                }
                else
                {
                    throw; 
                }
            }
            return true;
        }
        public async Task<bool> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                empname = employeeDTO.EmpName,
                isLaptopAssigned = employeeDTO.IsLaptopAssigned
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.empId == id);
        }
    }
}


