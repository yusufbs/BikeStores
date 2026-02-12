using ProductApi.Domain.Entities;

namespace ProductApi.Application.DTOs.Conversions;

public static class ProductConversions
{
    public static Product ToEntity(this ProductDTO product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Quantity = product.Quantity,
        Price = product.Price,
    };

    public static ProductDTO ToDTO(this Product product) => new ProductDTO
        (
            product.Id,
            product.Name!,
            product.Quantity,
            product.Price
        );

    public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Product> products)
    {
        return products.Select(p => ToDTO(p));
    }
}
