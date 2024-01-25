using TEG_api.Common.Enums;

namespace TEG_api.Common.DTOs
{
    public class MissionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string DifficultyType { get; set; }
    }
}