namespace ChatAppMVC.Models
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(string id);
        void Create(User user);
        void Update(string id, User user);
        void Delete(string id);


    }
}
