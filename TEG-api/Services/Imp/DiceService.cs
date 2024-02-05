using TEG_api.Common.DTOs;
using TEG_api.Common.GameLogic;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class DiceService : IDiceService
    {
        private readonly static Random random = new Random();
        private readonly ILogger<DiceService> _logger;

        public DiceService(ILogger<DiceService> logger)
        {
            _logger = logger;
        }

        public DicesResult ResolveDiceRoll(int NumbDicesA, int NumbDicesD, DiceDTO diceDTO, string AttackerColor, string DefenderColor)
        {
            DicesResult dicesResult = new DicesResult();

            //Attacker
            var valuesDicesA = ThrowDices(NumbDicesA, diceDTO);

            //Defender
            var valuesDicesD = ThrowDices(NumbDicesD, diceDTO);

            DicesComparer(valuesDicesA, valuesDicesD, ref dicesResult);

            dicesResult.Attacker = AttackerColor;
            dicesResult.Defender = DefenderColor;

            return dicesResult;
        }

        private void DicesComparer(List<int?> valuesDicesA, List<int?> valuesDicesD, ref DicesResult dicesResult)
        {
            int LengthDices = 0;
            
            if(valuesDicesA.Count != valuesDicesD.Count)
            {
                LengthDices = valuesDicesA.Count < valuesDicesD.Count ? valuesDicesA.Count : valuesDicesD.Count;
            }
            else
            {
                LengthDices = valuesDicesA.Count;
            }

            for (int i = 0; i < LengthDices; i++)
            {
                var WinnerA = valuesDicesA[i] >= valuesDicesD[i] ? true : false;
                var WinnerD = valuesDicesA[i] <= valuesDicesD[i] ? true : false;

                if (WinnerA == true && WinnerD == true)
                    WinnerA = false;

                dicesResult.DiceAttacker.Add(new DiceThrowed()
                {
                    Value = valuesDicesA[i].Value,
                    IsWinner = WinnerA,
                });
                dicesResult.DiceDefender.Add(new DiceThrowed()
                {
                    Value = valuesDicesD[i].Value,
                    IsWinner = WinnerD,
                });
            }
        }

        private List<int?> ThrowDices(int numbDices, DiceDTO diceDTO)
        {
            List<int?> result = new List<int?>(numbDices);

            for (int i = 0; i < numbDices; i++)
            {
                result.Add(random.Next(1, diceDTO.Faces + 1));
            }

            return result.OrderByDescending(x => x).ToList();
        }
    }
}
