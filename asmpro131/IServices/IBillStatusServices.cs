using asmpro131_Shared.Models;

namespace asmpro131.IServices
{
    public interface IBillStatusServices
    {
        public Task<bool> CreateBillStatusAsync(BillStatus p);

        public Task<bool> UpdateBillStatusAsync(BillStatus p);
        public Task<bool> DeleteBillStatusAsync(Guid id);
        public Task<BillStatus> GetBillStatusByIdAsync(Guid id);

        public Task<List<BillStatus>> GetAllBillStatusAsync();
    }
}
