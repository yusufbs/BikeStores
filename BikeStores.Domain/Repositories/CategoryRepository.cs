using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories;

public class CategoryRepository : IGenericRepository<Category>
{
    private readonly BikeStoresContext _context;
    public CategoryRepository(BikeStoresContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var category = GetById(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }

        Save();
    }

    public bool Exists(int id)
    {
        return _context.Categories.Any(e => e.CategoryId == id);
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category? GetById(int id)
    {
        return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
    }

    public void Insert(Category entity)
    {
        _context.Categories.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Category entity)
    {
        _context.Categories.Update(entity);
        Save();
    }
}
