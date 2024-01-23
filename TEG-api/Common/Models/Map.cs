using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Maps")]
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Continent> Continents { get; set; }
    }
}