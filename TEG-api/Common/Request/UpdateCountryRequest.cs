namespace TEG_api.Common.Request
{
    public class UpdateCountryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Troops { get; set; } = 1;
        public int ContinentId { get; set; }
        public Guid? OwnerID { get; set; }
    }
}
