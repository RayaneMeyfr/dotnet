namespace Restaurant.repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
