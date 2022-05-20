namespace ChatAppMVC.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int Contactid { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool Sent { get; set; }

        public string SentBy { get; set; } 
    }
}
