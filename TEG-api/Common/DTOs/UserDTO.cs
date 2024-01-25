using TEG_api.Common.Enums;
using TEG_api.Common.Models;

namespace TEG_api.Common.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
    }
}