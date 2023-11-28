using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.DTO;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public class EmployeeLaptopMappingService : IEmployeeLaptopMappingService
    {
        private readonly mntContext _context;

        public EmployeeLaptopMappingService(mntContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateMapping(EmployeeLaptopDTO employeeLaptopDTO)
        {
            try
            {
                var newMapping = new EmployeeLaptopMapping
                {
                    laptopId = employeeLaptopDTO.laptopId,
                    empId = employeeLaptopDTO.empId,
                    createdDate = employeeLaptopDTO.createdDate,
                    createdBy = employeeLaptopDTO.createdBy
                };

                _context.EmployeeLaptopMappings.Add(newMapping);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

            public Task<bool> DeleteMapping(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeLaptopMapping>> GetAllMappings()
        {
            try
            {
                var mappings = await _context.EmployeeLaptopMappings.ToListAsync();
                return mappings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<EmployeeLaptopMapping> GetMappingById(int id)
        {
            try
            {
                var mapping = await _context.EmployeeLaptopMappings.FindAsync(id);
                return mapping; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public async Task<bool> UpdateMapping(int id, EmployeeLaptopPutDTO employeeLaptopPutDTO)
        {
            try
            {
                var existingMapping = await _context.EmployeeLaptopMappings.FindAsync(id);
                if (existingMapping == null)
                {
                    return false;
                }
                existingMapping.laptopId = employeeLaptopPutDTO.laptopId;
                existingMapping.empId = employeeLaptopPutDTO.empId;
                existingMapping.createdDate = employeeLaptopPutDTO.createdDate;
                existingMapping.createdBy = employeeLaptopPutDTO.createdBy;

                _context.Entry(existingMapping).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }

    }
}
