using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Models;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class TurnControllerService : ITurnController
    {
        private readonly TEGContext _db;
        private readonly ILogger<TurnControllerService> _logger;

        public TurnControllerService(TEGContext db, ILogger<TurnControllerService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<string> CheckTurnActual(Guid MatchId)
        {
            var turnActual = await _db.Matches.Where(m => m.Id == MatchId).Select(m => m.TurnActual).FirstAsync();

            if (string.IsNullOrEmpty(turnActual.ToString()))
            {
                _logger.LogError($"TURNACTUAL_EMPTY | {MatchId}");
                return "TURNACTUAL_EMPTY";
            }

            return turnActual.ToString();
        }

        public async Task<string> NextTurn(Guid MatchId)
        {
            var Match = await _db.Matches.FirstAsync(m => m.Id == MatchId);

            if (Match == null)
            {
                _logger.LogError($"MATCH_EMPTY | {MatchId}");
                return "MATCH_EMPTY";
            }

            for (int i = 0; i < Match.TurnOrder.Count; i++)
            {
                if (Match.TurnOrder[i].Equals(Match.TurnActual))
                {
                    if(i + 1 < Match.TurnOrder.Count)
                    {
                        Match.TurnActual = Match.TurnOrder[i + 1];
                    }
                    else
                    {
                        //Thread - Trigger for new round
                        Thread checkLeftOver = new Thread(new ParameterizedThreadStart(NewRoundTrigger));
                        object parameters = new object[] { MatchId };
                        checkLeftOver.Start(parameters);

                        Match.TurnActual = Match.TurnOrder[0];
                    }

                    break;
                }
            }

            if (string.IsNullOrEmpty(Match.TurnActual.ToString()))
            {
                _logger.LogError($"TURNACTUAL_EMPTY | {MatchId} error to assign turn actual {Match.TurnOrder}");
                return "TURNACTUAL_EMPTY";
            }

            await _db.SaveChangesAsync();

            return Match.TurnActual.ToString();
        }

        private void NewRoundTrigger(object parameters)
        {
            var parametersArray = (object[])parameters;
            var matchId = (Guid)parametersArray[0];

            //TODO: WebsocketTrigger to Clients

        }
    }
}
