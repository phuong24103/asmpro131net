using asmpro131_Shared.Models;

namespace asmpro131.IServices
{
    public interface IVoucherService
    {
        public Task<bool> CreateVoucher(Voucher address);
        public Task<bool> UpdateVoucher(Voucher address);
        public Task<bool> DeleteVoucher(Guid id);
        public Task<Voucher> GetVoucherById(Guid id);
        public Task<List<Voucher>> GetVoucherByName(string name);
        public Task<List<Voucher>> GetAllVoucher();
    }
}
