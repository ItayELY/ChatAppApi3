namespace ChatApp2API.Models
{
    public class Message
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime created { get; set; }
        public bool sent { get; set; }
    }
}
