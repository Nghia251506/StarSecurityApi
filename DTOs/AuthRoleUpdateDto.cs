namespace StarSecurityApi.DTOs
{
    public class AuthRoleUpdateDto
    {
        public string? Description { get; set; }
        public bool CanManageEmployees { get; set; }
        public bool CanManageServices { get; set; }
        public bool CanManageVacancies { get; set; }
        public bool CanManageClients { get; set; }
    }
}
