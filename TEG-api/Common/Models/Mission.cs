using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEG_api.Common.Enums;

namespace TEG_api.Common.Models
{
    [Table("Missions")]
    public class Mission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public DifficultyType DifficultyType { get; set; }
        public virtual ICollection<PlayerGameSetup> PlayerGameSetups { get; set; }
    }
}