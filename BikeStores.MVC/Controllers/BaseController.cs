using BikeStores.Domain.Validators;
using BikeStores.Presentation.Generic.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BikeStores.MVC.Controllers;

public class BaseController<T> : Controller where T : class
{
    protected readonly IGenericRepository<T> _repository;
    protected readonly IValidator<T>? _validator;

    public BaseController(IGenericRepository<T> repository, IValidator<T>? validator = null)
    {
        _repository = repository;
        _validator = validator;
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
        PopulateViewData();
        return View();
    }

    // POST: {Entities}/Create
    public IActionResult CreatePost(T entity)
    {
        // only this contains fluent validation code
        // utilized in CustomersController
        ValidationResult? result = null;
        if (_validator is not null)
        {
            result = _validator.Validate(entity);
        }
        if (result?.IsValid ?? true)
        {
            _repository.Insert(entity);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            result?.AddToModelState(ModelState);
            PopulateViewData(entity);
            return View(entity);
        }
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
        PopulateViewData(entity);
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
        PopulateViewData(entity);
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
        PopulateViewData(entity);
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

    public virtual void PopulateViewData(T? entity = null)
    {
        // this remains empty in BaseController, DO NOT DELETE THIS
    }
}
