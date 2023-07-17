using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;

namespace asmpro131.IServices
{
    public interface IBillDetailsService
    {
        public Task<bool> CreateBillDetails(BillDetails address);
        public Task<bool> UpdateBillDetails(BillDetailsView address);
        public Task<bool> DeleteBillDetails(Guid id);
        public Task<List<BillDetailsView>> GetBillDetailsByBillId(Guid id);
        public Task<List<BillDetailsView>> GetAllBillDetails();
    }
}
