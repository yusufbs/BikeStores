using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

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
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Store> GetAll()
    {
        return _context.Stores;
    }

    public Store? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Store entity)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Store entity)
    {
        throw new NotImplementedException();
    }
}
