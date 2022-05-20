namespace ChatAppMVC.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public List<string> Interlocuters { get; set; }
        public List<Message> Messages { get; set; }

    }
}
