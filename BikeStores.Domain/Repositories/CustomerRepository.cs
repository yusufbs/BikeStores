using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories;

public class CustomerRepository : IGenericRepository<Customer>
{
    private readonly BikeStoresContext _context;
    public CustomerRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var customer = GetById(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }

        Save();
    }

    public bool Exists(int id)
    {
        return _context.Customers.Any(e => e.CustomerId == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.FirstOrDefault(x => x.CustomerId == id);
    }

    public void Insert(Customer entity)
    {
        _context.Customers.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Customer entity)
    {
        _context.Customers.Update(entity);
        Save();
    }
}
