using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class OrderItemRepository : IGenericOrderItemRepository
{
    private readonly BikeStoresContext _context;

    public OrderItemRepository(BikeStoresContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var orderItem = GetById(id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
        }

        Save();
    }

    public bool Exists(int id)
    {
        return _context.OrderItems.Any(e => e.ItemId == id);
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return _context.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Product);
    }

    public OrderItem? GetById(int id)
    {
        return _context.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Product)
            .FirstOrDefault(m => m.OrderId == id);
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products;
    }

    public void Insert(OrderItem entity)
    {
        _context.OrderItems.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(OrderItem entity)
    {
        _context.OrderItems.Update(entity);
        Save();
    }
}
