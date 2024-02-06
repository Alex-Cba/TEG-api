namespace TEG_api.Common.DTOs
{
    public class MapDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        //public List<MatchDTO>? Matches { get; set; }                  //ERROR AL POSTEAR MAPA - ARREGLAR
        //public List<ContinentDTO>? Continents { get; set; }           //ERROR AL POSTEAR MAPA - ARREGLAR
    }
}