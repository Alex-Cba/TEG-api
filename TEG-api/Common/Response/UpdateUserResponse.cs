namespace TEG_api.Common.Response
{
    public class UpdateUserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
    }
}
