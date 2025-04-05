using BikeStores.Domain.Models;

namespace BikeStores.Domain.Repositories;

public interface IDataRepository
{
    IEnumerable<Order> GetOrders();
    IEnumerable<Product> GetProducts();
    IEnumerable<Customer> GetCustomers();
    IEnumerable<Staff> GetStaffs();
    IEnumerable<Store> GetStores();
    IEnumerable<Brand> GetBrands();
    IEnumerable<Category> GetCategories();
}
