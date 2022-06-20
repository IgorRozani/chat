using Chatroom.Core.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.Core.Hubs
{
    public class SportChatHub : Hub, IChatHub
    {
        public static string Address => "/chat-sport";

        public async Task SendMessage(string user, string message, DateTime time)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, time);
        }
    }
}
