namespace TEG_api.Services.Interface
{
    public interface ITurnController
    {
        public Task<string> NextTurn(Guid MatchId);
        public Task<string> CheckTurnActual(Guid MatchId);
    }
}