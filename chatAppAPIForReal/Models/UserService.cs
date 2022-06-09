using chatAppAPIForReal;

namespace ChatAppMVC.Models
{

    public class UserService : IService<User>
    {
        private static List<User> _users = new List<User>() {
            new User("yonadav", "Yonadav", "123"),
            new User("itay", "Itay", "123"),
            new User("perki", "perki", "123")
        };
        public int MyProperty { get; set; }

        public void Create(User user)
        {
            using (var db = new UsersContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new UsersContext())
            {
                db.Remove(GetById(id));
                db.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            using(var db = new UsersContext())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public User GetById(string id)
        {
            using (var db = new UsersContext())
            {
                User? user = db.Users.Find(id);
                return user;
            }
        }

        public void Update(string id, User user)
        {
            Delete(id);
            Create(user);
        }


        internal static void InitContacts()
        {
            var chatService = new ChatService();
            var userService = new UserService();
            foreach (var chat in chatService.GetAll())
            {
                    /*
                foreach (var userId in chat.Interlocuters)
                {
                    var user = userService.GetById(userId);
                    //if (user.Contacts.Find(x=> x.Id == userId) == null)
                    var newCId = chat.Interlocuters.Find(x => x != userId);
                    var newC = userService.GetById(newCId);
                    user.AddContact(new Contact(newCId, newC.Name, newC.Server));
                }
                */
            }

        }
    }
}
