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

        public async Task<LaptopDTO> GetLaptopById(int id)
        {
            var laptop = await  _context.Laptops.FindAsync(id);
            if(laptop == null)
            {
                return null;
            }
            var laptopDTO = new LaptopDTO
            {
                serialNum = laptop.serialNum,
                modelNum = laptop.modelNum,
                brand = laptop.brand,
                operatingSystem = laptop.operatingSystem,
                ram = laptop.ram,
                battery = laptop.battery,
                mic = laptop.mic,
                keyBoard = laptop.keyBoard,
                mouse = laptop.mouse,
                speaker = laptop.speaker,
                charger = laptop.charger,
                isAssigned = laptop.isAssigned,
                storage = laptop.storage,
            };

            return laptopDTO;
        }

        public async Task<IEnumerable<LaptopDTO>> GetLaptops()
        {   //resolve
            //move this logic to repo
            var laptops = await _context.Laptops.ToListAsync();

            var laptopDTOs = laptops.Select(laptop=> new LaptopDTO
            {
                serialNum = laptop.serialNum,
                modelNum = laptop.modelNum,
                brand = laptop.brand,
                operatingSystem = laptop.operatingSystem,
                ram = laptop.ram,
                battery = laptop.battery,
                mic = laptop.mic,
                keyBoard = laptop.keyBoard,
                mouse = laptop.mouse,
                speaker = laptop.speaker,
                charger = laptop.charger,
                isAssigned = laptop.isAssigned,
                storage = laptop.storage,

            }).ToList();

            return laptopDTOs;
        }

        public async Task<bool> UpdateLaptop(int id, LaptopDTO laptopDTO)
        {
            var laptop =await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return false;
            }

                laptop.serialNum = laptopDTO.serialNum;
                laptop.modelNum = laptopDTO.modelNum; 
                laptop.brand = laptopDTO.brand;
                laptop.operatingSystem = laptopDTO.operatingSystem;
                laptop.ram = laptopDTO.ram;
                laptop.battery = laptopDTO.battery;
                laptop.mic = laptopDTO.mic;
                laptop.keyBoard = laptopDTO.keyBoard;
                laptop.mouse = laptopDTO.mouse;
                laptop.speaker = laptopDTO.speaker;
                laptop.charger = laptopDTO.charger;
                laptop.isAssigned = laptopDTO.isAssigned;
                laptop.storage = laptopDTO.storage;

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



        //public async Task<IEnumerable<Laptop>> GetLaptops()
        //{
        //    return await _context.Laptops.ToListAsync();
        //}
        //public async Task<Laptop> GetLaptopById(int id)
        //{
        //    return await _context.Laptops.FindAsync(id);
        //}
        //public async Task<bool> DeleteLaptop(int id)
        //{
        //    var laptop = await _context.Laptops.FindAsync(id);
        //    if(laptop==null)
        //    {
        //        return false;
        //    }

        //    _context.Laptops.Remove(laptop);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        //public async Task<bool> UpdateLaptop(int id, Laptop laptop)
        //{
        //    if(id != laptop.laptopId)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }

        //    catch(DbUpdateConcurrencyException)
        //    {
        //        if (!LaptopExists(id))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return true;
        //}
        //private bool LaptopExists(int id)
        //{
        //    return _context.Laptops.Any(l => l.laptopId == id);
        //}
        // async Task<bool> ILaptopService.CreateLaptop(LaptopDTO laptopDTO)
        //{
        //    var laptop = new Laptop
        //    {
        //        serialNum = laptopDTO.serialNum,
        //        modelNum = laptopDTO.modelNum,
        //        brand = laptopDTO.brand,
        //        operatingSystem = laptopDTO.operatingSystem,
        //        ram = laptopDTO.ram,
        //        battery = laptopDTO.battery,
        //        mic = laptopDTO.mic,
        //        keyBoard = laptopDTO.keyBoard,
        //        mouse = laptopDTO.mouse,
        //        speaker = laptopDTO.speaker,
        //        charger = laptopDTO.charger,
        //        isAssigned = laptopDTO.isAssigned,
        //        storage = laptopDTO.storage
        //    };
        //    _context.Laptops.Add(laptop);
        //    await _context.SaveChangesAsync();
        //    return false;
        //}

    }
}
