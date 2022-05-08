namespace ChatApp2API.Models
{
    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string server { get; set; }
        public string? last { get; set; }
        public DateTime? lastdate { get; set; }

        public List<Message>? messages { get; set; }
        public string Userid { get; set; }
    }
}
