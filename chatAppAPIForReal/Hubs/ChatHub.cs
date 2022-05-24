using ChatAppMVC.Models;
using Microsoft.AspNetCore.SignalR;

namespace chatAppAPIForReal.Hubs
{
    public class ChatHub : Hub<Clients.IClients>
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
