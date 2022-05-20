using System.ComponentModel.DataAnnotations;

namespace ChatAppMVC.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<Contact> Contacts { get; set; }

        public User(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            Contacts = new List<Contact>();
        }
        public void addContact(Contact c)
        {
            Contacts.Add(c);

        }
    }
}