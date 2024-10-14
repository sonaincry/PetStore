namespace BusinessObject.DTOs
{
    public class PaymentDetailDTO
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
