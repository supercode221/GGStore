using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [Required]
    [StringLength(100)]
    public string Sku { get; set; } = null!;

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalePrice { get; set; }

    public decimal? CostPrice { get; set; }

    public int? StockQuantity { get; set; }

    public int? MinStockLevel { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal? Weight { get; set; }

    [StringLength(100)]
    public string? Dimensions { get; set; }

    public int? WarrantyPeriod { get; set; }

    public bool? IsFeatured { get; set; }

    public bool? IsActive { get; set; }

    [StringLength(255)]
    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    [Required]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();

    public decimal DisplayPrice => SalePrice ?? Price;
    public bool HasDiscount => SalePrice.HasValue && SalePrice < Price;
    public decimal DiscountPercentage => HasDiscount ? Math.Round(((Price - SalePrice.Value) / Price) * 100) : 0;
    public double AverageRating => ProductReviews?.Any() == true ? ProductReviews.Where(r => (bool)r.IsApproved).Average(r => r.Rating) : 0;
    public int ReviewCount => ProductReviews?.Count(r => (bool)r.IsApproved) ?? 0;
}
