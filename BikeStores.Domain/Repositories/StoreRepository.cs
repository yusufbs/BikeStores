using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class StoreRepository : IGenericRepository<Store>
{
    private readonly BikeStoresContext _context;

    public StoreRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var store = GetById(id);
        if (store != null)
        {
            _context.Stores.Remove(store);
        }
        Save();
    }

    public bool Exists(int id)
    {
        return _context.Stores.Any(e => e.StoreId == id);
    }

    public IEnumerable<Store> GetAll()
    {
        return _context.Stores;
    }

    public Store? GetById(int id)
    {
        return _context.Stores
            .FirstOrDefault(m => m.StoreId == id);
    }

    public void Insert(Store entity)
    {
        _context.Stores.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Store entity)
    {
        _context.Update(entity);
        Save();
    }
}
