using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TEG_api.Common.Enums;
using TEG_api.Common.Request;
using TEG_api.Hubs;
using TEG_api.Middleware.Exceptions;
using TEG_api.Services.Interface;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalRController : Controller
    {
        private readonly IHubContext<PrincipalHub> _hubContext;
        private readonly IDiceService _diceService;

        public SignalRController(IHubContext<PrincipalHub> hubContext, IDiceService diceService)
        {
            _hubContext = hubContext;
            _diceService = diceService;
        }

        #region Communication
        [HttpPost("SendMessageAllPlayers")]
        public async Task<IActionResult> SendMessageAllPlayers([FromBody]string message)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("SendMessageAllPlayeres", message);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpPost("SendMessagePlayer")]
        public async Task<IActionResult> SendMessagePlayer([FromBody] string message)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("SendMessagePlayer", message);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
        #endregion

        [HttpPost("ReceiveDicesData")]
        public async Task<IActionResult> ReceiveDicesData([FromBody] DataDices data, [FromHeader] string connectionId)
        {
            TypePlayer value = (TypePlayer)Enum.Parse(typeof(TypePlayer), data.TypePlayer);
            PrincipalHub._socketsToFight.TryAdd(connectionId, (value, data));

            if (PrincipalHub._socketsToFight.Count >= 2)
            {
                await ResolveFight();
            }

            return Ok(true);
        }

        private async Task<bool> ResolveFight()
        {
            DataDices Attacker = null;
            DataDices Defender = null;

            if(PrincipalHub._socketsToFight.Count > 2)
            {
                throw new ExceptionBadRequestClient("ONLY_TWO_OPPONENTS");
            }

            foreach (var user in PrincipalHub._socketsToFight)
            {
                if (user.Value.Item1.Equals(TypePlayer.Attacker))
                {
                    Attacker = user.Value.Item2;
                }

                if (user.Value.Item1.Equals(TypePlayer.Defender))
                {
                    Defender = user.Value.Item2;
                }
            }

            var result = _diceService.ResolveDiceRoll(Attacker.NumberDices, Defender.NumberDices, new Common.DTOs.DiceDTO()
                                                        {
                                                            Faces = 6,
                                                        },
                                                        Attacker.Color,
                                                        Defender.Color);

            if (result == null)
            {
                throw new Exception("RESOLVE_FIGHT_ERROR");
            }

            await _hubContext.Clients.All.SendAsync("SendMessageAllPlayeres", result);
            PrincipalHub._socketsToFight.Clear();

            return true;
        }
    }
}
