using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductAttribute
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Unit { get; set; }

    public bool? IsFilterable { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
}
