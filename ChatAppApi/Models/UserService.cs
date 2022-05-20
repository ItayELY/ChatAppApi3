namespace ChatAppMVC.Models
{

    public class UserService
    {
        private static List<User> _users = new List<User>() {
            new User("yonadav", "Yonadav", "123"),
            new User("itay", "Itay", "123"),
            new User("noam", "Noam", "123")
        };    
        public int MyProperty { get; set; }
    }
}
