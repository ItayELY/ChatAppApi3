namespace ChatAppMVC.Models
{
    public class Message
    {
        private static int CountId = 1000;
        public int Id { get; set; }
       public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool Sent { get; set; }

        public string SentBy { get; set; }

        public Message(string content, DateTime created, bool sent, string sentBy)
        {
            Id = CountId;
            Content = content;
            Created = created;
            Sent = sent;
            SentBy = sentBy;
            CountId++;
        }

        public Message(int id, string content, DateTime created, bool sent, string sentBy)
        {
            Id = CountId;
            Content = content;
            Created = created;
            Sent = sent;
            SentBy = sentBy;
        }

    }
}
