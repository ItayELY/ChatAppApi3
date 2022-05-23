namespace chatAppAPIForReal.Models
{
    public class Transfer
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }


        Transfer(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }  
    }
}
