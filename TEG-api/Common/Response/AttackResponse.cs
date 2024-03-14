using TEG_api.Common.DTOs;
using TEG_api.Common.GameLogic;

namespace TEG_api.Common.Response
{
    public class AttackResponse
    {
        public DicesResult DicesResult { get; set; }
        public CountryDTO FromCountry { get; set; }
        public CountryDTO ToCountry { get; set; }
    }
}
