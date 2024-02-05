using Microsoft.EntityFrameworkCore;

namespace TEG_api.Common.DTOs
{
    public class DiceDTO
    {
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
    }
}