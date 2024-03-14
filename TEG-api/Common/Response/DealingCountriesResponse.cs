using TEG_api.Common.DTOs;

namespace TEG_api.Common.Response
{
    public class DealingCountriesResponse
    {
        public int MapId { get; set; }
        public MapDealingResponse Map { get; set; }
    }

    public class MapDealingResponse
    {
        public List<ContinentDealingResponse> Continents { get; set; }
    }

    public class ContinentDealingResponse
    {
        public int ContinentId { get; set; }
        public string Name { get; set; }
        public int ValueOfTroops { get; set; }
        public List<CountryDTO> Countries { get; set; }
    }
}
