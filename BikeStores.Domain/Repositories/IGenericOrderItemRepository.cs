using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories;

public interface IGenericOrderItemRepository : IGenericRepository<OrderItem>
{
    IEnumerable<Order> GetOrders();
    IEnumerable<Product> GetProducts();
}
