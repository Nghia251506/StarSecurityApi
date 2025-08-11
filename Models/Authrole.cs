public class AuthRole
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // 'admin','manager','staff'
    public string? Description { get; set; }
}
