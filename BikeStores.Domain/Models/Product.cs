using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BikeStores.Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public short ModelYear { get; set; }

    public decimal ListPrice { get; set; }
    
    [ValidateNever]
    public virtual Brand Brand { get; set; } = null!;
    
    [ValidateNever]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
