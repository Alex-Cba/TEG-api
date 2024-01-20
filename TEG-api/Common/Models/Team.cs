using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
    }
}