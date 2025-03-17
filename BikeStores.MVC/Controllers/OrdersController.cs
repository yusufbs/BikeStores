using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;

namespace BikeStores.MVC.Controllers;

public class OrdersController : Controller
{
    private readonly IGenericOrderRepository _repository;

    public OrdersController(IGenericOrderRepository repository)
    {
        _repository = repository;
    }

    // GET: Orders
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    // GET: Orders/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = _repository.GetById(id.Value);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
        return GetViewWithData();
    }

    private IActionResult GetViewWithData(Order? order = null)
    {
        if (order == null)
        {
            ViewData["CustomerId"] = new SelectList(_repository.GetCustomers(), "CustomerId", "Email");
            ViewData["StaffId"] = new SelectList(_repository.GetStaffs(), "StaffId", "Email");
            ViewData["StoreId"] = new SelectList(_repository.GetStores(), "StoreId", "StoreName");
            return View();
        }
        else
        {
            ViewData["CustomerId"] = new SelectList(_repository.GetCustomers(), "CustomerId", "Email", order.CustomerId);
            ViewData["StaffId"] = new SelectList(_repository.GetStaffs(), "StaffId", "Email", order.StaffId);
            ViewData["StoreId"] = new SelectList(_repository.GetStores(), "StoreId", "StoreName", order.StoreId);
            return View(order);
        }
    }

    // POST: Orders/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
    {
        if (ModelState.IsValid)
        {
            _repository.Insert(order);
            return RedirectToAction(nameof(Index));
        }
        return GetViewWithData(order);
    }

    // GET: Orders/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = _repository.GetById(id.Value);
        if (order == null)
        {
            return NotFound();
        }
        return GetViewWithData(order);
    }

    // POST: Orders/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
    {
        if (id != order.OrderId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(order.OrderId))
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
        return GetViewWithData(order);
    }

    // GET: Orders/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = _repository.GetById(id.Value);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
