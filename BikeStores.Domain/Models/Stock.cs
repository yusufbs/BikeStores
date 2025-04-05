using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BikeStores.Domain.Models;

public partial class Stock
{
    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    [ValidateNever]
    public virtual Product Product { get; set; } = null!;

    [ValidateNever]
    public virtual Store Store { get; set; } = null!;
}
