using System.ComponentModel.DataAnnotations;
using TEG_api.Common.DTOs;

namespace TEG_api.Common.Request
{
    public class AttackRequest
    {
        public int MatchId { get; set; }
        [Required]
        public Attacker Attacker { get; set; }
        [Required]
        public Defender Defender { get; set; }
    }

    public class Attacker
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public CountryDTO FromCountry { get; set; }
        public DataDices DataDices { get; set; }
    }

    public class Defender
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public CountryDTO ToCountry { get; set; }
        public DataDices DataDices { get; set; }
    }

}
