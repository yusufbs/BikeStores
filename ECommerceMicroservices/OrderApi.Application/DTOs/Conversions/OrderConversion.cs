using OrderApi.Domain.Entities;

namespace OrderApi.Application.DTOs.Conversions;

public static class OrderConversion
{
    public static Order ToEntity(this OrderDTO order) => new Order()
    {
        Id = order.Id,
        ClientId = order.ClientId,
        ProductId = order.ProductId,
        OrderedDate = order.OrderedDate,
        PurchaseQuantity = order.PurchaseQuantity,
    };

    public static OrderDTO ToDto(this Order order)
    {
        return new OrderDTO(
            order.Id,
            order.ProductId,
            order.ClientId,
            order.PurchaseQuantity,
            order.OrderedDate);
    }

    public static IEnumerable<OrderDTO> ToDto(this IEnumerable<Order> orders)
    {
        return orders.Select(o => ToDto(o));
    }
}
