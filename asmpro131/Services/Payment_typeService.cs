using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace asmpro131.Services
{
    public class Payment_typeService : IPayment_typeService
    {
        MyDbContext _context;
        public Payment_typeService()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> Createpayment(Payment payment)
        {
            if (payment == null) return false;
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePayment(Guid id)
        {
            try
            {
                var del = _context.Payments.Find(id);
                _context.Payments.Remove(del);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<Payment>> GetAllPayment()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
