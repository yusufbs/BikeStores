using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using BikeStores.Domain.Repositories;

namespace BikeStores.MVC.Controllers;

public class OrderItemsController : Controller
{
    private readonly IGenericOrderItemRepository _repository;

    public OrderItemsController(IGenericOrderItemRepository repository)
    {
        _repository = repository;
    }

    // GET: OrderItems
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    // GET: OrderItems/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var orderItem = _repository.GetById(id.Value);
        if (orderItem == null)
        {
            return NotFound();
        }

        return View(orderItem);
    }

    // GET: OrderItems/Create
    public IActionResult Create()
    {
        return GetViewWithData();
    }

    // POST: OrderItems/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("OrderId,ItemId,ProductId,Quantity,ListPrice,Discount")] OrderItem orderItem)
    {
        if (ModelState.IsValid)
        {
            _repository.Insert(orderItem);
            return RedirectToAction(nameof(Index));
        }
        return GetViewWithData(orderItem);
    }

    // GET: OrderItems/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var orderItem = _repository.GetById(id.Value);
        if (orderItem == null)
        {
            return NotFound();
        }
        return GetViewWithData(orderItem);
    }

    // POST: OrderItems/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("OrderId,ItemId,ProductId,Quantity,ListPrice,Discount")] OrderItem orderItem)
    {
        if (id != orderItem.OrderId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(orderItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(orderItem.OrderId))
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
        return GetViewWithData(orderItem);
    }

    // GET: OrderItems/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var orderItem = _repository.GetById(id.Value);
        if (orderItem == null)
        {
            return NotFound();
        }

        return View(orderItem);
    }

    // POST: OrderItems/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    private IActionResult GetViewWithData(OrderItem? orderItem = null)
    {
        if (orderItem == null)
        {
            ViewData["OrderId"] = new SelectList(_repository.GetOrders(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_repository.GetProducts(), "ProductId", "ProductName");
            return View();
        }
        else
        {
            ViewData["OrderId"] = new SelectList(_repository.GetOrders(), "OrderId", "OrderId", orderItem.OrderId);
            ViewData["ProductId"] = new SelectList(_repository.GetProducts(), "ProductId", "ProductName", orderItem.ProductId);
            return View(orderItem);
        }
    }
}
