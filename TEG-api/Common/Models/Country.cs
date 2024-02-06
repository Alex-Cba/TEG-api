using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Troops { get; set; } = 1;
        public int ContinentId { get; set; }
        [Column("OwnerID")]
        public Guid PlayerId { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<Country> BorderingCountries { get; set; }
    }
}