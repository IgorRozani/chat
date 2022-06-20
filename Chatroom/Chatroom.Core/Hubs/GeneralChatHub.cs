﻿using Chatroom.Core.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.Core.Hubs
{

    public class GeneralChatHub : Hub, IChatHub
    {
        public static string Address => "/chat-general";

        public async Task SendMessage(string user, string message, DateTime time)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, time);
        }
    }
}
