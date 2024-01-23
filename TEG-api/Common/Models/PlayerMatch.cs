using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("PlayerMatches")]
    public class PlayerMatch
    {
        [Key]
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Match Match { get; set; }
    }
}
