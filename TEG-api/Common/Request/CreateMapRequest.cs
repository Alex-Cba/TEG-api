using TEG_api.Common.DTOs;

namespace TEG_api.Common.Request
{
    public class CreateMapRequest
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }

        //public List<MatchDTO>? Matches { get; set; }           //ERROR AL POSTEAR MAPA - ARREGLAR
        //public List<ContinentDTO>? Continents { get; set; }    //ERROR AL POSTEAR MAPA - ARREGLAR
    }
}
