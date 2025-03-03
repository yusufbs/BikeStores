using BikeStores.MVC.Attributes;
using BikeStores.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStores.MVC.Controllers;

[GenericControllerName]
public class GenericController<T> : Controller, IGenericController<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericController(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public IEnumerable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Create(T entity)
    {
        _repository.Insert(entity);
        _repository.Save();
    }

    public void Update(T entity)
    {
        _repository.Update(entity);
        _repository.Save();
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _repository.Save();
    }
}
