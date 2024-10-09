using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class CartItemCreateDTO
    {
        [Required]
        public int CartId { get; set; } 

        [Required]
        public int ProductId { get; set; }  

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }  
    }
}