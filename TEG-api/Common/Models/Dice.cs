using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Dices")]
    public class Dice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }
        /// <summary>
        /// Number of Face (D_4, D_5, D_6, etc) 
        /// </summary>
        public int Faces { get; set; }
        /// <summary>
        /// Alters the probability, if it is 0 or null it does not alter the probability
        /// </summary>
        [Precision(5, 2)]
        public decimal? Probability { get; set; }
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}