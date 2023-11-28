using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.Model;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using YourNamespace.DTOs;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public class EmployeeLaptopMappingService : IEmployeeLaptopMappingService
    {
        private readonly mntContext _context;

        public EmployeeLaptopMappingService(mntContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMapping(EmployeeLaptopMappingDTO mappingDTO)
        {
            try
            {
                var mappingEntity = new EmployeeLaptopMapping
                {
                    empId = mappingDTO.EmployeeId,
                    laptopId = mappingDTO.LaptopId
                };

                _context.EmployeeLaptopMappings.Add(mappingEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Task<bool> DeleteMapping(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMapping(int id, EmployeeLaptopMappingDTO mappingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
