namespace ChatAppMVC.Models
{
    public class Contact
    {
        //public string UserId { get; set; }
        public string? Id { get; set; }
        //public string ContactId { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string? LastMessageContent { get; set; }
        public DateTime? LastMessageDate { get; set; }

        public Contact(string id, string name, string server)   
        {
            Id = id;
            Name = name;
            Server = server;
            
        }

    }
}
