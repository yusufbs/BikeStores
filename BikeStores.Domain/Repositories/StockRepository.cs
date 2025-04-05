using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class StockRepository : IGenericRepository<Stock>
{
    private readonly BikeStoresContext _context;

    public StockRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var stock = GetById(id);
        if (stock != null)
        {
            _context.Stocks.Remove(stock);
        }
        Save();
    }

    public bool Exists(int id)
    {
        return _context.Stocks.Any(e => e.StoreId == id);
    }

    public IEnumerable<Stock> GetAll()
    {
        return _context.Stocks
            .Include(s => s.Product)
            .Include(s => s.Store);
    }

    public Stock? GetById(int id)
    {
        return _context.Stocks
            .Include(s => s.Product)
            .Include(s => s.Store)
            .FirstOrDefault(m => m.StoreId == id);
    }

    public void Insert(Stock entity)
    {
        _context.Stocks.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Stock entity)
    {
        _context.Update(entity);
        Save();
    }
}
