namespace TEG_api.Common.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Troops { get; set; } = 1;
        public int ContinentId { get; set; }
        public Guid? OwnerID { get; set; }
    }
}
