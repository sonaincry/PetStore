using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPaymentDetailRepository
    {
        Task<PaymentDetail> AddPaymentDetailAsync(PaymentDetail paymentDetail);
        Task<PaymentDetail> GetPaymentDetailByOrderIdAsync(int orderId);
        Task<List<PaymentDetail>> GetPaymentDetailsAsync();
        Task<List<PaymentDetail>> GetPaymentDetailsByUserIdAsync(int userId);
    }
}
