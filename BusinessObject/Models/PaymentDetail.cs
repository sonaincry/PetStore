using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class PaymentDetail
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public decimal? Amount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Order? Order { get; set; }
}
