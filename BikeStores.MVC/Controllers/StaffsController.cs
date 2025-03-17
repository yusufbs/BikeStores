using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Data;
using BikeStores.Domain.Models;

namespace BikeStores.MVC.Controllers;

public class StaffsController : Controller
{
    private readonly BikeStoresContext _context;

    public StaffsController(BikeStoresContext context)
    {
        _context = context;
    }

    // GET: Staffs
    public async Task<IActionResult> Index()
    {
        var bikeStoresContext = _context.Staffs.Include(s => s.Manager).Include(s => s.Store);
        return View(await bikeStoresContext.ToListAsync());
    }

    // GET: Staffs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _context.Staffs
            .Include(s => s.Manager)
            .Include(s => s.Store)
            .FirstOrDefaultAsync(m => m.StaffId == id);
        if (staff == null)
        {
            return NotFound();
        }

        return View(staff);
    }

    // GET: Staffs/Create
    public IActionResult Create()
    {
        ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email");
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
        return View();
    }

    // POST: Staffs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,Email,Phone,Active,StoreId,ManagerId")] Staff staff)
    {
        if (ModelState.IsValid)
        {
            _context.Add(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email", staff.ManagerId);
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", staff.StoreId);
        return View(staff);
    }

    // GET: Staffs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _context.Staffs.FindAsync(id);
        if (staff == null)
        {
            return NotFound();
        }
        ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email", staff.ManagerId);
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", staff.StoreId);
        return View(staff);
    }

    // POST: Staffs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("StaffId,FirstName,LastName,Email,Phone,Active,StoreId,ManagerId")] Staff staff)
    {
        if (id != staff.StaffId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(staff.StaffId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email", staff.ManagerId);
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", staff.StoreId);
        return View(staff);
    }

    // GET: Staffs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _context.Staffs
            .Include(s => s.Manager)
            .Include(s => s.Store)
            .FirstOrDefaultAsync(m => m.StaffId == id);
        if (staff == null)
        {
            return NotFound();
        }

        return View(staff);
    }

    // POST: Staffs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var staff = await _context.Staffs.FindAsync(id);
        if (staff != null)
        {
            _context.Staffs.Remove(staff);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StaffExists(int id)
    {
        return _context.Staffs.Any(e => e.StaffId == id);
    }
}
