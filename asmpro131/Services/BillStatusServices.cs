using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class BillStatusServices : IBillStatusServices
    {
        MyDbContext _context;
        public BillStatusServices()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateBillStatusAsync(BillStatus p)
        {
            try
            {
                await _context.BillStatuses.AddAsync(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBillStatusAsync(Guid id)
        {
            try
            {
                var billStatus = await _context.BillStatuses.FirstOrDefaultAsync(c => c.Id == id);
                _context.BillStatuses.Remove(billStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public async Task<List<BillStatus>> GetAllBillStatusAsync()
        {
            return await _context.BillStatuses.ToListAsync();
        }

        public async Task<BillStatus> GetBillStatusByIdAsync(Guid id)
        {
            return await _context.BillStatuses.FirstOrDefaultAsync(c => c.Id == id);
        }

    

        public async Task<bool> UpdateBillStatusAsync(BillStatus p)
        {
            try
            {
                _context.BillStatuses.Update(p);
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
