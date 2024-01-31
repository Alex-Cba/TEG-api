namespace TEG_api.Common.Request
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
    }
}
