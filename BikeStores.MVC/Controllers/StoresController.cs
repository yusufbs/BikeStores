﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Data;
using BikeStores.Domain.Models;

namespace BikeStores.MVC.Controllers;

public class StoresController : Controller
{
    private readonly BikeStoresContext _context;

    public StoresController(BikeStoresContext context)
    {
        _context = context;
    }

    // GET: Stores
    public async Task<IActionResult> Index()
    {
        return View(await _context.Stores.ToListAsync());
    }

    // GET: Stores/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores
            .FirstOrDefaultAsync(m => m.StoreId == id);
        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }

    // GET: Stores/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Stores/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StoreId,StoreName,Phone,Email,Street,City,State,ZipCode")] Store store)
    {
        if (ModelState.IsValid)
        {
            _context.Add(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(store);
    }

    // GET: Stores/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores.FindAsync(id);
        if (store == null)
        {
            return NotFound();
        }
        return View(store);
    }

    // POST: Stores/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName,Phone,Email,Street,City,State,ZipCode")] Store store)
    {
        if (id != store.StoreId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(store);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(store.StoreId))
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
        return View(store);
    }

    // GET: Stores/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores
            .FirstOrDefaultAsync(m => m.StoreId == id);
        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }

    // POST: Stores/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var store = await _context.Stores.FindAsync(id);
        if (store != null)
        {
            _context.Stores.Remove(store);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StoreExists(int id)
    {
        return _context.Stores.Any(e => e.StoreId == id);
    }
}
