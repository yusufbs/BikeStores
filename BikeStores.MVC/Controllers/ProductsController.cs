using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class ProductsController : BaseController<Product>
{
    private readonly IDataRepository _dataRepository;

    public ProductsController(IGenericRepository<Product> repository, IDataRepository dataRepository) : base(repository)
    {
        _dataRepository = dataRepository;
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("ProductId,ProductName,BrandId,CategoryId,ModelYear,ListPrice")] Product product)
    {
        return CreatePost(product);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ProductId,ProductName,BrandId,CategoryId,ModelYear,ListPrice")] Product product)
    {
        return EditPost(product, id == product.ProductId, product.ProductId);
    }

    public override void PopulateViewData(Product? entity = null)
    {
        if (entity == null)
        {
            ViewData["BrandId"] = new SelectList(_dataRepository.GetBrands(), "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(_dataRepository.GetCategories(), "CategoryId", "CategoryName");
        }
        else
        {
            ViewData["BrandId"] = new SelectList(_dataRepository.GetBrands(), "BrandId", "BrandName", entity.BrandId);
            ViewData["CategoryId"] = new SelectList(_dataRepository.GetCategories(), "CategoryId", "CategoryName", entity.CategoryId);
        }
    }
}
