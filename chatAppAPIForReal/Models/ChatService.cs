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
            _chats.Add(entity);

        }

        public void Delete(string id)
        {
            _chats.Remove(GetById(id));
        }

        public List<Chat> GetAll()
        {
            return _chats;
        }

        public Chat GetById(string id)
        {
            return _chats.Find(x => x.Id == id);
        }
        public Chat GetBy2Users(string id1, string id2)
        {
            return _chats.Find(x => (x.Interlocuter1.Equals(id1) && x.Interlocuter2.Equals(id2)) || 
                (x.Interlocuter2.Equals(id1) && x.Interlocuter1.Equals(id2)));
        }

        public void Update(string id, Chat entity)
        {
            _chats.Remove(GetById(id));
            _chats.Add(entity);
        }
        public Message GetLastMessage(string id1, string id2)
        {
            Chat c = this.GetBy2Users(id1, id2);
            //   c.Messages.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
            //return c.Messages.First();
            return new Message(1, "hi", DateTime.Now, true, id1, c.Id);
        }
    }
}
