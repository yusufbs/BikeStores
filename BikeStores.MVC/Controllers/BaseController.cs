using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores.MVC.Controllers;

public class BaseController<T> : Controller where T : class
{
    protected readonly IGenericRepository<T> _repository;
    public BaseController(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    // GET: {Entities}
    public IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    // GET: {Entities}/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = _repository.GetById(id.Value);
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    // GET: {Entities}/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: {Entities}/Create
    public IActionResult CreatePost(T entity)
    {
        if (ModelState.IsValid)
        {
            _repository.Insert(entity);
            return RedirectToAction(nameof(Index));
        }
        return View(entity);
    }

    // GET: {Entities}/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = _repository.GetById(id.Value);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    // POST: {Entities}/Edit
    public IActionResult EditPost(T entity, bool idCheck, int entityId)
    {
        if (!idCheck)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(entityId))
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
        return View(entity);
    }

    // GET: {Entities}/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = _repository.GetById(id.Value);
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    // POST: {Entities}/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
