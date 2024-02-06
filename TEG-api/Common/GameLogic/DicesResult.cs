namespace TEG_api.Common.GameLogic
{
    public class DicesResult
    {
        public DicesResult()
        {
            DiceAttacker = new List<DiceThrowed>();
            DiceDefender = new List<DiceThrowed>();
            Attacker = String.Empty;
            Defender = String.Empty;
        }

        public List<DiceThrowed> DiceAttacker { get; set; }
        public List<DiceThrowed> DiceDefender { get; set; }
        public string Attacker { get; set; }
        public int UnitLostA { get; set; }
        public string Defender { get; set; }
        public int UnitLostB { get; set; }
        public string Winner  { get; set; }
    }

    public class DiceThrowed
    {
        public int Value { get; set; }
        public bool IsWinner { get; set; }
    }
}
