﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? VariantId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductSku { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductVariant? Variant { get; set; }
}
