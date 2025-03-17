using BikeStores.Domain.Data;
using BikeStores.Domain.Models;

namespace BikeStores.Domain.Repositories;

public class DataRepository : IDataRepository
{
    private readonly BikeStoresContext _context;

    public DataRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public IEnumerable<Brand> GetBrands()
    {
        return _context.Brands;
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return _context.Customers;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products;
    }

    public IEnumerable<Staff> GetStaffs()
    {
        return _context.Staffs;
    }

    public IEnumerable<Store> GetStores()
    {
        return _context.Stores;
    }
}
