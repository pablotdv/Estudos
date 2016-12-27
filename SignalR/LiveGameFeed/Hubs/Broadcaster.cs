using System.Threading.Tasks;
using LiveGameFeed.Models;
using Microsoft.AspNetCore.SignalR;

namespace LiveGameFeed.Hubs
{
    public class Broadcaster : Hub<IBroadcaster>
    {
        public override Task OnConnected()
        {
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }
        public Task Subscribe(int matchId)
        {
            return Groups.Add(Context.ConnectionId, matchId.ToString());
        }
        public Task Unsubscribe(int matchId)
        {  
            return Groups.Remove(Context.ConnectionId, matchId.ToString());
        }
    }

    public interface IBroadcaster
    {
        Task SetConnectionId(string connectionId);
        Task UpdateMatch(MatchViewModel match);
        Task AddFeed(FeedViewModel feed);
        Task AddChatMessage(ChatMessage message);
    }
}