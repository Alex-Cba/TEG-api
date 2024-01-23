using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<MatchConfig> MatchSetups { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<MissionsPlayer> Missions{ get; set; }
    }
}