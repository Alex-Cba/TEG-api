using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEG_api.Common.Enums;

namespace TEG_api.Common.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public virtual Player? Player { get; set; }
    }
}