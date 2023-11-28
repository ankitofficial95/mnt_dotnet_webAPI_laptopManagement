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
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.employees
                .ToListAsync();

            return employees;
        }


        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _context.employees.FindAsync(id);
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
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve employee details.", ex);
            }
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = await _context.employees.FindAsync(id);
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

            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
        private bool EmployeeExists(int id)
        {
            return _context.employees.Any(e => e.empId == id);
        }


    }
}


