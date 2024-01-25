namespace TEG_api.Common.DTOs
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public bool IsActive { get; set; }
    }
}