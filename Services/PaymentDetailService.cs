using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly IPaymentDetailRepository _paymentDetailRepository;
        private readonly IMapper _mapper;

        public PaymentDetailService(IPaymentDetailRepository paymentDetailRepository, IMapper mapper)
        {
            _paymentDetailRepository = paymentDetailRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDetail> AddPaymentDetailAsync(PaymentDetailDTO paymentDetailDTO)
        {
            var paymentDetail = _mapper.Map<PaymentDetail>(paymentDetailDTO);
            return await _paymentDetailRepository.AddPaymentDetailAsync(paymentDetail);
        }

        public async Task<PaymentDetail> GetPaymentDetailByOrderIdAsync(int orderId)
        {
            return await _paymentDetailRepository.GetPaymentDetailByOrderIdAsync(orderId);
        }

        public async Task<List<PaymentDetail>> GetPaymentDetailsAsync()
        {
            return await _paymentDetailRepository.GetPaymentDetailsAsync();
        }

        public async Task<List<PaymentDetail>> GetPaymentDetailsByUserIdAsync(int userId)
        {
            return await _paymentDetailRepository.GetPaymentDetailsByUserIdAsync(userId);
        }
    }
}
