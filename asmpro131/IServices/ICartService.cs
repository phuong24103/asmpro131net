using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;

namespace asmpro131.IServices
{
    public interface ICartService
    {
        public Task<bool> CreateCart(Cart address);
        public Task<bool> UpdateCart(CartView address);
        public Task<bool> DeleteCart(Guid id);
        public Task<CartView> GetCartById(Guid id);
        public Task<List<CartView>> GetAllCart();
    }
}
