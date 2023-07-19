using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;

namespace asmpro131.IServices
{
    public interface IPayment_typeService
    {
        public Task<bool> Createpayment(Payment payment);
        public Task<bool> UpdatePayment(Payment payment);
        public Task<bool> DeletePayment(Guid id);
        public Task<Payment> GetPaymentById(Guid id);
        public Task<List<Payment>> GetAllPayment();
    }
}
