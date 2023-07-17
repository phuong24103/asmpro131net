using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class BillServices : IBillService
    {
        MyDbContext _context;
        public BillServices()
        {
            _context = new MyDbContext();
        }

        public async Task<bool> CreateBill(Bill address)
        {
            if (address == null) return false;
            await _context.Bills.AddAsync(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBill(Guid id)
        {
            try
            {
                var del = _context.Bills.Find(id);
                _context.Bills.Remove(del);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BillView>> GetAllBills()
        {
            List<BillView> billViews = new List<BillView>();
            billViews = await (
                from a in _context.Bills
                join b in _context.Vouchers on a.VoucherID equals b.Id
                join c in _context.Accounts on a.AccountID equals c.Id
                join d in _context.Payments on a.Id equals d.Id
                join e in _context.BillStatuses on a.Id equals e.Id

                select new BillView()
                {
                    Bill = a,
                    Voucher = b,
                    Account = c,
                    Payment = d,
                    BillStatus = e,
                }).ToListAsync();
            return billViews;
        }

        public async Task<List< BillView>> GetBillByAccountId(Guid id)
        {
            List<BillView> lstBillViews = new List<BillView>();
            lstBillViews = await (
                from a in _context.Bills
                join b in _context.Vouchers on a.VoucherID equals b.Id
                join c in _context.Accounts on a.AccountID equals c.Id
                join d in _context.Payments on a.Id equals d.Id
                join e in _context.BillStatuses on a.Id equals e.Id

                select new BillView()
                {
                    Bill = a,
                    Voucher = b,
                    Account = c,
                    Payment = d,
                    BillStatus = e,
                }).ToListAsync();
            AccountView accountView = new AccountView();
            accountView = await (
                from a in _context.Accounts
                join b in _context.Roles on a.RoleId equals b.Id
                join c in _context.Ranks on a.RankID equals c.Id
                where a.Id == id
                select new AccountView()
                {
                    Account = a,
                    Role = b,
                    Rank = c
                }).FirstAsync();
            if (accountView.Role.Id == Guid.Parse(""))
            {
                return lstBillViews;
            }
            return lstBillViews.Where(p => p.Account.Id == id).ToList();
        }

        public async Task<BillView> GetBillById(Guid id)
        {
            List<BillView> billViews = new List<BillView>();
            billViews = await (
                from a in _context.Bills
                join b in _context.Vouchers on a.VoucherID equals b.Id
                join c in _context.Accounts on a.AccountID equals c.Id
                join d in _context.Payments on a.Id equals d.Id
                join e in _context.BillStatuses on a.Id equals e.Id

                select new BillView()
                {
                    Bill = a,
                    Voucher = b,
                    Account = c,
                    Payment = d,
                    BillStatus = e,
                }).ToListAsync();
            return billViews.FirstOrDefault(p => p.Bill.Id == id);
        }

        public async Task<bool> UpdateBill(BillView address)
        {
            try
            {
                var up = _context.Bills.Find(address.Bill.Id);
                up.Price = address.Bill.Price;
                up.CreateDate = address.Bill.CreateDate;
                up.Status = address.Bill.Status;
                //up.Voucher = address.Bill.Voucher;
                _context.Bills.Update(up);
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
