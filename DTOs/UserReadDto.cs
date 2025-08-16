namespace StarSecurityApi.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public int Employee_id { get; set; }
        public string? Username { get; set; }
        public string? Password_hash { get; set; }
        public int Auth_role_id { get; set; }
        public AuthRole AuthRole { get; set; }
        public DateTime? Last_login { get; set; }
        public DateTime CreateAt { get; set; }
    }
}