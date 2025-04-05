using Microsoft.AspNetCore.Mvc;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class StoresController : BaseController<Store>
{
    public StoresController(IGenericRepository<Store> repository) : base(repository) {}

    // POST: Stores/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("StoreId,StoreName,Phone,Email,Street,City,State,ZipCode")] Store store)
    {
        return CreatePost(store);
    }

    // POST: Stores/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("StoreId,StoreName,Phone,Email,Street,City,State,ZipCode")] Store store)
    {
        var idCheck = id != store.StoreId;
        return EditPost(store, idCheck, store.StoreId);
    }
}
