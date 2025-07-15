using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrderAddress
{
    public int AddressId { get; set; }

    public int? OrderId { get; set; }

    public string AddressType { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Company { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string? State { get; set; }

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual Order? Order { get; set; }
}
