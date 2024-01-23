using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Configurations")]
    public class Configuration
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 1st exchange -> 4 armies
        /// 2nd exchange -> 7 armies
        /// 3rd exchange -> 10 armies
        /// ----From here on, increase by 5 armies each time---
        /// 4rd exchange -> 15 armies
        /// 5rd exchange -> 20 armies
        /// </summary>
        public int ChangesInGame { get; set; } = 0;
        /// <summary>
        /// Default 6
        /// </summary>
        public int NumberOfDices { get; set; } = 6;
        public virtual Dice Dice { get; set; }
        public virtual ICollection<MatchConfig> MatchSetup { get; set; }
    }
}