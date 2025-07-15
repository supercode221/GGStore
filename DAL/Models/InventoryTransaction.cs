using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class InventoryTransaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }

    public int? VariantId { get; set; }

    public string TransactionType { get; set; } = null!;

    public int Quantity { get; set; }

    public string ReferenceType { get; set; } = null!;

    public int? ReferenceId { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductVariant? Variant { get; set; }
}
