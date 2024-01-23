using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Dices")]
    public class Dice
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        /// <summary>
        /// Number of Face (D_4, D_5, D_6, etc) 
        /// </summary>
        public int DiceType { get; set; }
        /// <summary>
        /// Alters the probability, if it is 0 or null it does not alter the probability
        /// </summary>
        [Precision(5, 2)]
        public decimal? probability { get; set; }
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}