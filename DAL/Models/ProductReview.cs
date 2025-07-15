using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class ProductReview
{
    [Key]
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    public string? ReviewText { get; set; }

    public bool? IsVerifiedPurchase { get; set; }

    public bool? IsApproved { get; set; }

    public int? HelpfulCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
