using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.Domain.Repositories
{
    public class BrandRepository : IGenericRepository<Brand>
    {
        private readonly BikeStoresContext _context;
        public BrandRepository(BikeStoresContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var brand = GetById(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }

            Save();
        }

        public bool Exists(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands;
        }

        public Brand? GetById(int id)
        {
            return _context.Brands.FirstOrDefault(x => x.BrandId == id);
        }

        public void Insert(Brand entity)
        {
            _context.Brands.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Brand entity)
        {
            _context.Brands.Update(entity);
            Save();
        }
    }
}
