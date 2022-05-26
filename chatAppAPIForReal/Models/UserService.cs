namespace ChatAppMVC.Models
{

    public class UserService : IService<User>
    {
        private static List<User> _users = new List<User>() {
            new User("yonadav", "Yonadav", "123"),
            new User("itay", "Itay", "123"),
            new User("shtusel", "shtusel", "123"),
            new User("kingDavid", "KingDavid", "123"),
            new User("kingSolomon", "KingSolomon", "123"),
            new User("kingHezekiah", "KingHezekiah", "123")
        };
        public int MyProperty { get; set; }

        public void Create(User user)
        {
            _users.Add(user);
        }

        public void Delete(string id)
        {
            _users.Remove(GetById(id));
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(string id)
        {
            return _users.Find(x => x.Id == id);
        }

        public void Update(string id, User user)
        {
            _users.Remove(GetById(id));
            _users.Add(user);
        }


        internal static void InitContacts()
        {
            var chatService = new ChatService();
            var userService = new UserService();
            foreach (var chat in chatService.GetAll())
            {
                foreach (var userId in chat.Interlocuters)
                {
                    var user = userService.GetById(userId);
                    //if (user.Contacts.Find(x=> x.Id == userId) == null)
                    var newCId = chat.Interlocuters.Find(x => x != userId);
                    var newC = userService.GetById(newCId);
                    user.AddContact(new Contact(newCId, newC.Name, newC.Server));
                }
            }

        }
    }
}
