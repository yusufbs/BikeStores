using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;

namespace BikeStores.MVC.Controllers;

public class ProductsController : Controller
{
    private readonly IGenericProductRepository _repository;

    public ProductsController(IGenericProductRepository repository)
    {
        _repository = repository;
    }

    // GET: Products
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    // GET: Products/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _repository.GetById(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        return GetViewWithData();
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("ProductId,ProductName,BrandId,CategoryId,ModelYear,ListPrice")] Product product)
    {
        if (ModelState.IsValid)
        {
            _repository.Insert(product);
            return RedirectToAction(nameof(Index));
        }
        return GetViewWithData(product);
    }

    // GET: Products/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _repository.GetById(id.Value);
        if (product == null)
        {
            return NotFound();
        }
        return GetViewWithData(product);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ProductId,ProductName,BrandId,CategoryId,ModelYear,ListPrice")] Product product)
    {
        if (id != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(product.ProductId))
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
        return GetViewWithData(product);
    }

    // GET: Products/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _repository.GetById(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    private IActionResult GetViewWithData(Product? product = null)
    {
        if (product == null)
        {
            ViewData["BrandId"] = new SelectList(_repository.GetBrands(), "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "CategoryId", "CategoryName");
            return View();
        }
        else
        {
            ViewData["BrandId"] = new SelectList(_repository.GetBrands(), "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
    }
}
