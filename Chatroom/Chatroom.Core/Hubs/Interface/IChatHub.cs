namespace Chatroom.Core.Hubs.Interface
{
    public interface IChatHub
    {
        static string Address { get; }

        Task SendMessage(string user, string message, DateTime time);
    }
}
