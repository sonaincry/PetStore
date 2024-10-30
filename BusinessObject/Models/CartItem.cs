using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    [JsonIgnore]
    public virtual Cart? Cart { get; set; }

    [JsonIgnore]
    public virtual Product? Product { get; set; }
}
