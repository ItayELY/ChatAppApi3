namespace chatAppAPIForReal.Models
{
    public class Invitation
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Server { get; set; }


        public Invitation(string from, string to, string server)
        {
            From = from;
            To = to;
            Server = server;
        }
    }
}
