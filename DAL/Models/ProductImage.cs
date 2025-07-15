using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class ProductImage
{
    [Key]
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public int? VariantId { get; set; }

    [Required]
    [StringLength(255)]
    public string ImageUrl { get; set; } = null!;

    [StringLength(255)]
    public string? AltText { get; set; }

    public bool? IsPrimary { get; set; }

    public int? DisplayOrder { get; set; }

    [StringLength(20)]
    public string? ImageType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductVariant? Variant { get; set; }
}
