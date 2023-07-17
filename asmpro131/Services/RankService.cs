using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class RankService : IRankService
    {
        MyDbContext _context;
        public RankService()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateRank(Rank address)
        {
            if (address == null) return false;
            await _context.Ranks.AddAsync(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRank(Guid id)
        {
            try
            {
                var delrank = _context.Ranks.Find(id);
                _context.Ranks.Remove(delrank);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Rank>> GetAllRank()
        {
            return await _context.Ranks.ToListAsync();
        }

        public async Task<Rank> GetRankById(Guid id)
        {
            return await _context.Ranks.AsQueryable().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public  async Task<List<Rank>> GetRankByName(string name)
        {
            return await _context.Ranks.AsQueryable().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<bool> UpdateRank(Rank address)
        {
            try
            {
                var n = _context.Ranks.Find(address.Id);
                n.Name = address.Name;
                n.Point = address.Point;
                _context.Update(n);
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
