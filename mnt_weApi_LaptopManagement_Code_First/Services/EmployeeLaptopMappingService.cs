using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.Model;
using YourNamespace.DTOs;

namespace YourNamespace.Services
{
    public class EmployeeLaptopMappingService : IEmployeeLaptopMappingService
    {
        private readonly mntContext _context;

        public EmployeeLaptopMappingService(mntContext context)
        {
            _context = context;
        }

        public async Task<EmployeeLaptopMappingDTO> CreateMapping(EmployeeLaptopMappingDTO mappingDTO)
        {
            try
            {
                var mappingEntity = new EmployeeLaptopMapping
                {
                    empId = mappingDTO.EmployeeId,
                    laptopId = mappingDTO.LaptopId,
                    isReturned = mappingDTO.IsReturned
                };

          
                _context.EmployeeLaptopMappings.Add(mappingEntity);
                await _context.SaveChangesAsync();

                // Assuming the mappingEntity is generated with the database-assigned ID
                // You might need to adjust this based on your setup if the ID is generated differently
                mappingDTO.MappingId = mappingEntity.MappingId;

                return mappingDTO;
            }
            catch (Exception ex)
            {
                // Handle exceptions or logging if needed
                throw new Exception("Failed to create mapping.", ex);
            }
        }


        public Task<bool> DeleteMapping(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeLaptopMappingDTO>> GetAllMappings()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeLaptopMappingDTO> GetMappingById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMapping(int id, EmployeeLaptopMappingDTO mappingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
