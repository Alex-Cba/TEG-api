using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Drawing;
using System.Net.WebSockets;
using TEG_api.Services.Interface;

namespace TEG_api.Hubs
{
    public class TestHub : Hub
    {
        private readonly ConcurrentDictionary<string, DataDices> _sockets = new ConcurrentDictionary<string, DataDices>();
        private readonly TaskCompletionSource<bool> _waitingInfoTask = new TaskCompletionSource<bool>();
        private readonly IDiceService _diceService;
        private int _SendedData = 0;

        public TestHub(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public async Task OnConnectedAsyncAttaker()
        {
            var connectionId = Context.ConnectionId;

            _sockets.TryAdd(connectionId+ "_A", new DataDices());
            
            await base.OnConnectedAsync();
        }

        public async Task OnConnectedAsyncDefender()
        {
            var connectionId = Context.ConnectionId;

            _sockets.TryAdd(connectionId + "_D", new DataDices());

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;

            DataDices Dummy;

            _sockets.TryRemove(connectionId, out Dummy);

            await base.OnDisconnectedAsync(exception);
        }

        public async Task WaitingForRoll()
        {
            await _waitingInfoTask.Task;

            await Clients.Caller.SendAsync("SendMessagePlayer", "Esperando al otro jugador");
        }

        public async Task SendMessagePlayer(string message)
        {
            await Clients.Caller.SendAsync("SendMessagePlayer", message);
        }

        public async Task SendMessageAllPlayeres(string message)
        {
            await Clients.All.SendAsync("SendMessageAllPlayeres", message);
        }

        public async Task DataReceive(DataDices data)
        {
            if(_SendedData < 2)
            {
                await Clients.Caller.SendAsync("SendMessagePlayer", "Información incorrecta");
            }

            var connectionId = Context.ConnectionId;

            _sockets.TryAdd(connectionId, data);
            _SendedData++;
            _waitingInfoTask.SetResult(true);
        }

        public async Task AllDataReiceve()
        {
            if (_SendedData < 2)
            {
                _waitingInfoTask.SetResult(false);
            }

            _waitingInfoTask.SetResult(true);

            DataDices Attacker = null;
            DataDices Defender = null;

            foreach (var user in _sockets)
            {
                if (user.Key.EndsWith("_A"))
                {
                    Attacker = user.Value;
                }

                if (user.Key.EndsWith("_D"))
                {
                    Defender = user.Value;
                }
            }

            var result = _diceService.ResolveDiceRoll(Attacker.NumberDices, Defender.NumberDices, new Common.DTOs.DiceDTO()
                                                        {
                                                            Faces = 6,
                                                        },
                                                        Attacker.Color,
                                                        Defender.Color);

            await Clients.All.SendAsync("SendMessageAllPlayeres", result);
        }
    }

    public class DataDices
    {
        public int NumberDices { get; set; }
        public string Color { get; set; }
    }
}
