using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEG_api.Common.Enums;

namespace TEG_api.Common.Models
{
    [Table("Matchs")]
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset CreationDateUTC { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public int Points { get; set; }
        public int Winner { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
