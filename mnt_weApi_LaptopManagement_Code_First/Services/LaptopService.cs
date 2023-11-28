using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using mnt_weApi_LaptopManagement_Code_First.DTO;
using mnt_weApi_LaptopManagement_Code_First.DTOs;
using mnt_weApi_LaptopManagement_Code_First.Model;
using System;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace mnt_weApi_LaptopManagement_Code_First.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly mntContext _context;
        public LaptopService(mntContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateLaptop(LaptopDTO laptopDTO)
        {
            var laptop = new Laptop
            {
                serialNum = laptopDTO.serialNum,
                modelNum = laptopDTO.modelNum,
                brand = laptopDTO.brand,
                operatingSystem = laptopDTO.operatingSystem ,
                ram = laptopDTO.ram,
                battery = laptopDTO.battery,    
                mic = laptopDTO.mic ,
                keyBoard = laptopDTO.keyBoard ,
                mouse   = laptopDTO.mouse ,
                speaker = laptopDTO.speaker ,
                charger = laptopDTO.charger ,
                isAssigned = laptopDTO.isAssigned ,
                storage = laptopDTO.storage ,
                CreatedBy = laptopDTO.CreatedBy,
                CreatedDate = laptopDTO.CreatedDate,
            };

            //change the logic 
            _context.Laptops.Add(laptop);
            //this also 
            await _context.SaveChangesAsync();

            //impl try catch here
            //log (in file or DB)
            //send id/model 
            return true;
        }
        public async Task<bool> DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return false;
            }
            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Laptop> GetLaptopById(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            return laptop;
        }

        public async Task<IEnumerable<Laptop>> GetLaptops()
        {   //resolve
            //move this logic to repo
            var laptops = await _context.Laptops.ToListAsync();
            return laptops;
        }

        public async Task<bool> UpdateLaptop(int id, LaptopPutDto laptopPutDto)
        {
            var laptop =await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return false;
            }
                laptop.serialNum = laptopPutDto.serialNum;
                laptop.modelNum = laptopPutDto.modelNum; 
                laptop.brand = laptopPutDto.brand;
                laptop.operatingSystem = laptopPutDto.operatingSystem;
                laptop.ram = laptopPutDto.ram;
                laptop.battery = laptopPutDto.battery;
                laptop.mic = laptopPutDto.mic;
                laptop.keyBoard = laptopPutDto.keyBoard;
                laptop.mouse = laptopPutDto.mouse;
                laptop.speaker = laptopPutDto.speaker;
                laptop.charger = laptopPutDto.charger;
                laptop.isAssigned = laptopPutDto.isAssigned;
                laptop.storage = laptopPutDto.storage;
                laptop.CreatedBy = laptopPutDto.CreatedBy;
                laptop.CreatedDate = laptopPutDto.CreatedDate;
                laptop.ModifiedDate = laptopPutDto.ModifiedDate;
                laptop.ModifiedBy = laptopPutDto.ModifiedBy;          

            _context.Entry(laptop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopExists(id))
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
        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(l => l.laptopId == id);
        }
    }
}
