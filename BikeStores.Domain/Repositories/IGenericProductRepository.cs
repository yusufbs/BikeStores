using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories;

public interface IGenericProductRepository : IGenericRepository<Product>
{
    IEnumerable<Brand> GetBrands();
    IEnumerable<Category> GetCategories();
}
