using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("PlayerGameSetup")]
    public class PlayerGameSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public Guid MatchId { get; set; }
        public int MissionId { get; set; }
        public virtual Player Player { get; set; }
        public virtual Match Match { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
