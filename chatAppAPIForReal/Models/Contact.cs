using System.ComponentModel.DataAnnotations;

namespace ChatAppMVC.Models
{
    public class Contact
    {
        [Key]
        public string ContactKey { get; set; }
        public string UserId { get; set; }
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string? LastMessageContent { get; set; }
        public String? LastMessageDate { get; set; }

        public Contact(string userId, string id, string name, string server)   
        {
            UserId = userId;
            Id = id;
            Name = name;
            Server = server;
            ContactKey = userId + id;    
        }

    }
}
