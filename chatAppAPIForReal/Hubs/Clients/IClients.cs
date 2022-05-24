using ChatAppMVC.Models;
using System.Threading.Tasks;

namespace chatAppAPIForReal.Hubs.Clients
{
        public interface IClients
        {
            Task ReceiveMessage(string message);
        }
    
}
