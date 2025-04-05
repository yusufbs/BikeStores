using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.Domain.Repositories;

public class StaffRepository : IGenericRepository<Staff>
{
    private readonly BikeStoresContext _context;

    public StaffRepository(BikeStoresContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var staff = GetById(id);
        if (staff != null)
        {
            _context.Staffs.Remove(staff);
        }
        Save();
    }

    public bool Exists(int id)
    {
        return _context.Staffs.Any(e => e.StaffId == id);
    }

    public IEnumerable<Staff> GetAll()
    {
        return _context.Staffs
            .Include(s => s.Manager)
            .Include(s => s.Store);
    }

    public Staff? GetById(int id)
    {
        return _context.Staffs
            .Include(s => s.Manager)
            .Include(s => s.Store)
            .FirstOrDefault(m => m.StaffId == id);
    }

    public void Insert(Staff entity)
    {
        _context.Staffs.Add(entity);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Staff entity)
    {
        _context.Staffs.Update(entity);
        Save();
    }
}
