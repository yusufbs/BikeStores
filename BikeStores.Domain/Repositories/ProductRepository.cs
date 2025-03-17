using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class ProductRepository : IGenericProductRepository
{
    private readonly BikeStoresContext _context;

    public ProductRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }

        Save();
    }

    public bool Exists(int id)
    {
        return _context.Products.Any(x => x.ProductId == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category);
    }

    public IEnumerable<Brand> GetBrands()
    {
        return _context.Brands;
    }

    public Product? GetById(int id)
    {
        return _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .FirstOrDefault(m => m.ProductId == id);
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories;
    }

    public void Insert(Product entity)
    {
        _context.Products.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
        Save();
    }
}
