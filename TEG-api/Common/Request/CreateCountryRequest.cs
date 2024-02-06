namespace TEG_api.Common.Request
{
    public class CreateCountryRequest
    {
        public string Name { get; set; }
        public int Troops { get; set; }
        public int ContinentId { get; set; }
        public Guid? PlayerId { get; set; }
        public int Continent { get; set; }
    }
}
