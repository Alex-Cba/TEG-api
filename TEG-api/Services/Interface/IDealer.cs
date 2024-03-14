using TEG_api.Common.Enums;

namespace TEG_api.Services.Interface
{
    public interface IDealer
    {
        public Task DealingCountries(int MatchId);
        public Task<bool> ChangeCard(List<TypeOfCard> cards, Guid playerId, Guid MatchId);
    }
}
