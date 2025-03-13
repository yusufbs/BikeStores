using BikeStores.Presentation.Generic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStores.Presentation.Generic.Controllers;

public class GenericController<T> : Controller, IGenericController<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericController(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<T> GetAll()
    {
        return _repository.GetAll();
    }

    [HttpGet("{id}")]
    public T? GetById(int id)
    {
        return _repository.GetById(id);
    }

    [HttpPost("{id}")]
    public void Create(T entity)
    {
        _repository.Insert(entity);
        _repository.Save();
    }

    [HttpPut("{id}")]
    public void Update(T entity)
    {
        _repository.Update(entity);
        _repository.Save();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _repository.Delete(id);
        _repository.Save();
    }
}
