using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int TeamId { get; set; }
        public Guid? UserId { get; set; }
        public virtual Team Team { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<PlayerGameSetup> PlayerGameSetups { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}