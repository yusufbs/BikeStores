﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BikeStores.Domain.Models;

public partial class OrderItem
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal ListPrice { get; set; }

    public decimal Discount { get; set; }

    [ValidateNever]
    public virtual Order Order { get; set; } = null!;

    [ValidateNever]
    public virtual Product Product { get; set; } = null!;
}
