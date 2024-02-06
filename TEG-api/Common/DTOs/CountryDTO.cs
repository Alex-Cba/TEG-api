using TEG_api.Common.Models;

namespace TEG_api.Common.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Troops { get; set; }
        public int ContinentId { get; set; }
        public Guid? PlayerId { get; set; }
        public virtual Continent? Continent { get; set; }

    }
}
