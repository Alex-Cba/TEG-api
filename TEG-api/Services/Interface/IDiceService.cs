using TEG_api.Common.DTOs;
using TEG_api.Common.GameLogic;

namespace TEG_api.Services.Interface
{
    public interface IDiceService
    {
        public DicesResult ResolveDiceRoll(int NumbDicesA, int NumbDicesD, DiceDTO diceDTO, string AttackerColor, string DefenderColor);
    }
}
