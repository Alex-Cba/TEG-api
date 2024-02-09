namespace TEG_api.Common.Response
{
    public class UpdateCountryResponse
    {
        public string Name { get; set; }
        public int Troops { get; set; } = 1;
        public int ContinentId { get; set; }
        public Guid? OwnerID { get; set; }
    }
}
