namespace TEG_api.Common.Request
{
    public class UpdateMapRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
