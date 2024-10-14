using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentDetailService
    {
        Task<PaymentDetail> AddPaymentDetailAsync(PaymentDetailDTO paymentDetailDTO);
        Task<PaymentDetail> GetPaymentDetailByOrderIdAsync(int orderId);
        Task<List<PaymentDetail>> GetPaymentDetailsAsync();

        Task<List<PaymentDetail>> GetPaymentDetailsByUserIdAsync(int userId);
    }
}
