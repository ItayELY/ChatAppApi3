namespace ChatAppMVC.Models
{
    public class Message
    {
        public int id { get; set; }
        public int Contactid { get; set; }
        public string content { get; set; }
        public DateTime created { get; set; }
        public bool sent { get; set; }
    }
}
