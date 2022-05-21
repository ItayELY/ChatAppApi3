namespace ChatAppMVC.Models
{
    public class Chat
    {
        public string Id { get; set; }
        public List<string> Interlocuters { get; set; }
        public List<Message> Messages { get; set; }

        public Chat(string id, List<string> interlocuters, List<Message> messages)
        {
            Id = id;
            Interlocuters = interlocuters;
            Messages = messages;
        }
        
       
    }
}
