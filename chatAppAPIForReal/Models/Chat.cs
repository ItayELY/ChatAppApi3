namespace ChatAppMVC.Models
{
    public class Chat
    {
        public string Id { get; set; }
        //public List<string> Interlocuters { get; set; }
        public string Interlocuter1 { get; set; }
        public string Interlocuter2 { get; set; }

     //   public List<Message> Messages { get; set; }

        public Chat(string id, string interlocuter1, string interlocuter2)
        {
            Id = id;
            Interlocuter1 = interlocuter1;
            Interlocuter2 = interlocuter2;

        }

        
       
    }
}
