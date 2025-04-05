using Microsoft.AspNetCore.Mvc;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class CategoriesController : BaseController<Category>
{
    public CategoriesController(IGenericRepository<Category> repository) : base(repository) { }

    // POST: Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("CategoryId,CategoryName")] Category category)
    {
        return CreatePost(category);
    }

    // POST: Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("CategoryId,CategoryName")] Category category)
    {
        return EditPost(category, id == category.CategoryId, category.CategoryId);
    }
}
