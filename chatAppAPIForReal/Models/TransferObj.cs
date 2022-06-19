using System.Text.Json.Serialization;

namespace chatAppAPIForReal.Models
{
    public class TransferObj
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonConstructor]
        public TransferObj(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public TransferObj()
        {

        }
    }
}
