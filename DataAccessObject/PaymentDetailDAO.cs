using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class PaymentDetailDAO
    {
        private static PaymentDetailDAO instance = null;
        private readonly PetStoreContext dbContext = null;

        private PaymentDetailDAO()
        {
            dbContext = new PetStoreContext();
        }

        public static PaymentDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDetailDAO();
                }
                return instance;
            }
        }

        public async Task<PaymentDetail> AddPaymentDetailAsync(PaymentDetail paymentDetail)
        {
            await dbContext.PaymentDetails.AddAsync(paymentDetail);
            await dbContext.SaveChangesAsync();
            return paymentDetail;
        }

        public async Task<PaymentDetail> GetPaymentDetailByOrderIdAsync(int orderId)
        {
            return await dbContext.PaymentDetails.FirstOrDefaultAsync(pd => pd.OrderId == orderId);
        }

        public async Task<List<PaymentDetail>> GetPaymentDetailsAsync()
        {
            return await dbContext.PaymentDetails.ToListAsync();
        }
        public async Task<List<PaymentDetail>> GetPaymentDetailsByUserIdAsync(int userId)
        {
            var paymentDetails = await dbContext.PaymentDetails
                .Where(pd => pd.Order != null && pd.Order.UserId == userId)
                .ToListAsync();

            return paymentDetails;
        }
    }

}
