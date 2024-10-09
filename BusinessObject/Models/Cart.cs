using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User? User { get; set; }
}
