using Microsoft.AspNetCore.SignalR;

namespace Chatroom.Core.Hubs
{

    public class GeneralChatHub : Hub
    {
        public const string ADDRESS = "/chat-general";

        public async Task SendMessage(string user, string message, DateTime time)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, time);
        }
    }
}
