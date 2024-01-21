using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("MatchConfigs")]
    public class MatchConfig
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey("MatchId")]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}