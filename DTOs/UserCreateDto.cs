namespace StarSecurityApi.Dtos
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public int? Employee_id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? Password_hash { get; set; }
        public int? Auth_role_id { get; set; }
        public DateTime? Last_login { get; set; }
        public DateTime CreateAt { get; set; }
    }
}