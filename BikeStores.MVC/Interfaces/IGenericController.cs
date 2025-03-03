namespace BikeStores.MVC.Interfaces;

public interface IGenericController<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(int id);
}
