using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models.DTO
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; } = null!;
    }
}
