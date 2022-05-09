using System.ComponentModel.DataAnnotations;

namespace ChatAppMVC.Models
{
    public class User
    {
        [Key]
        public string id { get; set; }
        public string? name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public List<Contact>? contacts { get; set; }

        public void addContact(Contact c)
        {
            contacts.Add(c);

        }
    }
}