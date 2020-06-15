namespace mbe
{
    public interface IRepository<T>
    {
        T Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
