using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        public async Task<PaymentDetail> AddPaymentDetailAsync(PaymentDetail paymentDetail)
        {
            return await PaymentDetailDAO.Instance.AddPaymentDetailAsync(paymentDetail);
        }

        public async Task<PaymentDetail> GetPaymentDetailByOrderIdAsync(int orderId)
        {
            return await PaymentDetailDAO.Instance.GetPaymentDetailByOrderIdAsync(orderId);
        }

        public async Task<List<PaymentDetail>> GetPaymentDetailsAsync()
        {
            return await PaymentDetailDAO.Instance.GetPaymentDetailsAsync();
        }

        public Task<List<PaymentDetail>> GetPaymentDetailsByUserIdAsync(int userId)=>PaymentDetailDAO.Instance.GetPaymentDetailsByUserIdAsync(userId);
    }
}
