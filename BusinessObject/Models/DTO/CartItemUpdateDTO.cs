using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class CartItemUpdateDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }  
    }
}
