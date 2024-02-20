using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using TEG_api.Common.Enums;
using TEG_api.Common.Request;

namespace TEG_api.Hubs
{
    public class PrincipalHub : Hub
    {
        public static List<string> _sockets = new List<string>();
        public static ConcurrentDictionary<string, (TypePlayer, DataDices)> _socketsToFight = new ConcurrentDictionary<string, (TypePlayer, DataDices)>();

        #region Connection
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            _sockets.Add(connectionId);

            return base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;

            (TypePlayer, DataDices) Dummy;

            _sockets.Remove(connectionId);
            _socketsToFight.TryRemove(connectionId, out Dummy);

            await base.OnDisconnectedAsync(exception);
        }
        #endregion

        #region Communication
        public async Task SendMessagePlayer(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("SendMessagePlayer", message);
        }

        public async Task SendMessageAllPlayeres(string message)
        {
            await Clients.All.SendAsync("SendMessageAllPlayeres", message);
        }
        #endregion
    }
}
