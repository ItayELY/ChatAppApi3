namespace ChatAppMVC.Models
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        void Update(string id, T entity);
        void Delete(T entity);


    }
}
