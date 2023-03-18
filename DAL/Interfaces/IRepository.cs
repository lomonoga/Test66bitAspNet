namespace Test66bit.DAL.Interfaces;

public interface IRepository<T>
    where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int? id);
    void Create(T item);
    void CreateRange(params T[] items);
    void Update(T item);
    void Delete(int id);
    T GetFirstOfDefault(T item);
}