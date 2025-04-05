using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class OrderRepository : IGenericRepository<Order>
{
    private readonly BikeStoresContext _context;
    public OrderRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var order = GetById(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }

        Save();
    }

    public bool Exists(int id)
    {
        return _context.Orders.Any(e => e.OrderId == id);
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Staff)
            .Include(o => o.Store);
    }

    public Order? GetById(int id)
    {
        return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Staff)
                .Include(o => o.Store)
                .FirstOrDefault(m => m.OrderId == id);
    }

    public void Insert(Order entity)
    {
        _context.Orders.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Order entity)
    {
        _context.Orders.Update(entity);
        Save();
    }
}
