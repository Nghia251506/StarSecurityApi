using StarSecurityApi.Models;

public class User
{
    public int Id { get; set; }
    public int? EmployeeId { get; set; }
    public string? FullName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Employee Employee { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int? AuthRoleId { get; set; }
    public AuthRole AuthRole { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
}