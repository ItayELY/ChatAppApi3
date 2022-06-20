using chatAppAPIForReal;

namespace ChatAppMVC.Models
{
    public class ChatService : IService<Chat>
    {
        public static List<Chat> _chats =
            new List<Chat>();
            /*
        {
            new Chat("1", new List<string>
            {
                "yonadav", "itay"
            },new List<Message>{ 
                new Message(1, "HI!!!!", DateTime.Now, true, "yonadav"),
                new Message(2, "What up??", DateTime.Now, false, "itay"),
                new Message(3, "I am good", DateTime.Now, true, "yonadav"),
                new Message(4, "glad to hear", DateTime.Now, false, "itay"),
            }),
            new Chat("2", new List<string>
            {
                "yonadav", "perki"
            },new List<Message>{
                new Message(1, "HI!!!! perki", DateTime.Now, true, "yonadav"),
                new Message(2, "What up??", DateTime.Now, false, "perki"),
                new Message(3, "I am good", DateTime.Now, true, "yonadav"),
                new Message(4, "glad to hear", DateTime.Now, false, "perki"),
            })
        };
            */
        public void Create(Chat entity)
        {
            using (var db = new Context())
            {
                if (GetById(entity.Id) == null)
                {
                    db.Add(entity);
                    db.SaveChanges();
                }
               
            }

        }

        public void Delete(Chat entity)
        {
            using (var db = new Context())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<Chat> GetAll()
        {
            using (var db = new Context())
            {
                return db.chats.ToList();
            }
        }

        public Chat GetById(string id)
        {
            using (var db = new Context())
            {
                List<Chat> chats =  db.chats.ToList();
            
                return chats.Find(x => x.Id == id);
            }
        }
        public Chat GetBy2Users(string id1, string id2)
        {
            using (var db = new Context())
            {
                List<Chat> chats = db.chats.ToList();

                return chats.Find(x => (x.Interlocuter1.Equals(id1) && x.Interlocuter2.Equals(id2)) ||
                (x.Interlocuter2.Equals(id1) && x.Interlocuter1.Equals(id2)));
            }
            
        }

        public void Update(string id, Chat entity)
        {
            Delete(GetById(id));
            Create(entity);
        }
        public Message GetLastMessage(string id1, string id2)
        {
            using (var db = new Context())
            {
                Chat c = this.GetBy2Users(id1, id2);
                List<Message> messages = db.messages.Where(x => x.ChatId == c.Id).ToList();
                Message latest = messages.MaxBy(x => x.Id);
                return latest;
            }
                
        }
    }
}
