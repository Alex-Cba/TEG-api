using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("MissionsPlayers")]
    public class MissionsPlayer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey("MissionId")]
        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
    }
}