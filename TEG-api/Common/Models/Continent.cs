using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Continents")]
    public class Continent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValueOfTroops { get; set; }
        public virtual ICollection<Map> Maps { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}