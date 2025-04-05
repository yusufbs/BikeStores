using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class OrdersController : BaseController<Order>
{
    private readonly IDataRepository _dataRepository;

    public OrdersController(IGenericRepository<Order> repository, IDataRepository dataRepository) : base(repository)
    {
        _dataRepository = dataRepository;
    }

    // POST: Orders/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
    {
        return CreatePost(order);
    }

    // POST: Orders/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("OrderId,CustomerId,OrderStatus,OrderDate,RequiredDate,ShippedDate,StoreId,StaffId")] Order order)
    {
        return EditPost(order, id == order.OrderId, order.OrderId);
    }

    public override void PopulateViewData(Order? entity = null)
    {
        if (entity == null)
        {
            ViewData["CustomerId"] = new SelectList(_dataRepository.GetCustomers(), "CustomerId", "Email");
            ViewData["StaffId"] = new SelectList(_dataRepository.GetStaffs(), "StaffId", "Email");
            ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName");
        }
        else
        {
            ViewData["CustomerId"] = new SelectList(_dataRepository.GetCustomers(), "CustomerId", "Email", entity.CustomerId);
            ViewData["StaffId"] = new SelectList(_dataRepository.GetStaffs(), "StaffId", "Email", entity.StaffId);
            ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName", entity.StoreId);
        }
    }
}
