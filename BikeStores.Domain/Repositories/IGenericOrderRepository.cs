using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories
{
    public interface IGenericOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Staff> GetStaffs();
        IEnumerable<Store> GetStores();
    }
}
