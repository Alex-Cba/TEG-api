using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}