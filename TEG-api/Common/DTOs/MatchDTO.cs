namespace TEG_api.Common.DTOs
{
    public class MatchDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDateUTC { get; set; }
        public DateTimeOffset? SaveDateUTC { get; set; }
        public DateTimeOffset? EndDateUTC { get; set; }
        public string MatchStatus { get; set; }
        public int Winner { get; set; }
        public int MapId { get; set; }
        public int MatchConfigId { get; set; }
    }
}