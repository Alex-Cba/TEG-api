using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Troops { get; set; } = 1;
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public virtual Player Owner { get; set; }
        public virtual ICollection<Continent> Continents { get; set; }
    }
}