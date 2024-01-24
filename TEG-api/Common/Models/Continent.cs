using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Continents")]
    public class Continent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValueOfTroops { get; set; }
        public int MapId { get; set; }
        public virtual Map Map { get; set; }
        public virtual ICollection<Country> Countries { get; set;}
    }
}