using TEG_api.Common.DTOs;

namespace TEG_api.Services.Interface
{
    public interface IDiceService
    {
        public List<DicesResult> ThrowDices(int NumbDicesP1, int NumbDicesP2, DiceDTO diceDTO);
    }
}
