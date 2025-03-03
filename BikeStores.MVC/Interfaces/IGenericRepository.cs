namespace BikeStores.MVC.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Delete(int id);
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Insert(T entity);
    void Save();
    void Update(T entity);
}