using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? DiscountName { get; set; }

    public string? Description { get; set; }

    public decimal DiscountPercentage { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
