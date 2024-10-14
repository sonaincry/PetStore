using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailService _paymentDetailService;
        private readonly IMapper _mapper;

        public PaymentDetailController(IPaymentDetailService paymentDetailService, IMapper mapper)
        {
            _paymentDetailService = paymentDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var paymentDetails = await _paymentDetailService.GetPaymentDetailsAsync();
            return Ok(paymentDetails);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetPaymentDetailByOrderId(int orderId)
        {
            var paymentDetail = await _paymentDetailService.GetPaymentDetailByOrderIdAsync(orderId);

            if (paymentDetail == null)
            {
                return NotFound($"No payment detail found for Order ID {orderId}.");
            }

            return Ok(paymentDetail);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPaymentDetailByUserId(int userId)
        {
            var paymentDetails = await _paymentDetailService.GetPaymentDetailsByUserIdAsync(userId);

            if (paymentDetails == null || !paymentDetails.Any())
            {
                return NotFound($"No payment detail found for User ID {userId}.");
            }

            return Ok(paymentDetails);
        }


        [HttpPost]
        public async Task<IActionResult> AddPaymentDetail([FromBody] PaymentDetailDTO paymentDetailDTO)
        {
            if (paymentDetailDTO == null)
            {
                return BadRequest("Invalid payment detail data.");
            }

            var paymentDetail = await _paymentDetailService.AddPaymentDetailAsync(paymentDetailDTO);

            if (paymentDetail == null)
            {
                return StatusCode(500, "An error occurred while creating the payment detail.");
            }

            return Ok(paymentDetail);
        }
    }
}
