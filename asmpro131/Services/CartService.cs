using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class CartService : ICartService
    {
        MyDbContext _context;
        public CartService()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateCart(Cart address)
        {
            if (address == null) return false;
            await _context.Carts.AddAsync(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCart(Guid id)
        {
            try
            {
                var del = _context.Carts.Find(id);
                _context.Carts.Remove(del);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<CartView>> GetAllCart()
        {
            List<CartView> cartView = new List<CartView>();
            cartView = await (
                from a in _context.Carts
                join b in _context.Accounts on a.AccountID equals b.Id
                select new CartView()
                {
                    Cart = a,
                    Account = b,
                }).ToListAsync();
            return cartView;
        }

        public async Task<CartView> GetCartById(Guid id)
        {
            List<CartView> cartView = new List<CartView>();
            cartView = await (
                from a in _context.Carts
                join b in _context.Accounts on a.AccountID equals b.Id
                select new CartView()
                {
                    Cart = a,
                    Account = b,
                }).ToListAsync();
            return cartView.FirstOrDefault(p => p.Cart.AccountID == id);
        }

        public async Task<bool> UpdateCart(CartView address)
        {
            try
            {
                var up = _context.Carts.Find(address.Cart.AccountID);
                up.Description = address.Cart.Description;
                _context.Carts.Update(up);
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
