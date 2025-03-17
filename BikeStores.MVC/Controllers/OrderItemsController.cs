using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class OrderItemsController : BaseController<OrderItem>
{
    private readonly IDataRepository _dataRepository;

    public OrderItemsController(IGenericRepository<OrderItem> repository, IDataRepository dataRepository) : base(repository)
    {
        _dataRepository = dataRepository;
    }

    // POST: OrderItems/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("OrderId,ItemId,ProductId,Quantity,ListPrice,Discount")] OrderItem orderItem)
    {
        return CreatePost(orderItem);
    }

    // POST: OrderItems/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("OrderId,ItemId,ProductId,Quantity,ListPrice,Discount")] OrderItem orderItem)
    {
        return EditPost(orderItem, id == orderItem.OrderId, orderItem.OrderId);
    }

    public override void PopulateViewData(OrderItem? entity = null)
    {
        if (entity == null)
        {
            ViewData["OrderId"] = new SelectList(_dataRepository.GetOrders(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_dataRepository.GetProducts(), "ProductId", "ProductName");
        }
        else
        {
            ViewData["OrderId"] = new SelectList(_dataRepository.GetOrders(), "OrderId", "OrderId", entity.OrderId);
            ViewData["ProductId"] = new SelectList(_dataRepository.GetProducts(), "ProductId", "ProductName", entity.ProductId);
        }
    }
}
