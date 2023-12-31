﻿using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class SizeService : ISizeService
    {
        MyDbContext _context;
        public SizeService()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateSize(Size address)
        {
            if (address == null) return false;
            await _context.Sizes.AddAsync(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSize(Guid id)
        {
            try
            {
                var delsize = _context.Sizes.Find(id);
                _context.Sizes.Remove(delsize);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Size>> GetAllSize()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetSizeById(Guid id)
        {
            return await _context.Sizes.AsQueryable().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Size>> GetSizeByName(string name)
        {
            return await _context.Sizes.AsQueryable().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<bool> UpdateSize(Size address)
        {
            try
            {
                var s = _context.Sizes.Find(address.Id);
                s.Name = address.Name;
                s.Status = address.Status;
                _context.Update(s);
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
