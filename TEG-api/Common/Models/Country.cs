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
        [ForeignKey("PlayerId")]
        [Column("OwnerID")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey("Continent")]
        public int ContinentId { get; set; }
        public virtual Continent Continent { get; set; }
    }
}