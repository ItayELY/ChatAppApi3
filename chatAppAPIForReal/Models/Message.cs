using System.ComponentModel.DataAnnotations;

namespace ChatAppMVC.Models
{
    public class Message
    {
        private static int CountId = 1000;
        public string ChatId { get; set; }
        [Key]
        public int Id { get; set; }
       public string Content { get; set; }
        public String Created { get; set; }
        public bool Sent { get; set; }

        public string SentBy { get; set; }

        public Message(string content, string created, bool sent, string sentBy, string chatId)
        {
            CountId++;
            Content = content;
            Created = created;
            Sent = sent;
            SentBy = sentBy;
            ChatId = chatId;
        }

        public Message(int id, string content, string created, bool sent, string sentBy, string chatId)
        {
            Content = content;
            Created = created;
            Sent = sent;
            SentBy = sentBy;
            ChatId=chatId;
        }

    }
}
