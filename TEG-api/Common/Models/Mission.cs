using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEG_api.Common.Enums;

namespace TEG_api.Common.Models
{
    [Table("Missions")]
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DifficultyType DifficultyType { get; set; }
        public virtual ICollection<MissionsPlayer> MissionsPlayers { get; set; }
    }
}