using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("MatchConfigs")]
    public class MatchConfig
    {
        [Key]
        public int Id { get; set; }
        public virtual Configuration Configuration  { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}