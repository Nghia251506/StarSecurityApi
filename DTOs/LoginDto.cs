namespace StarSecurityApi.Dtos.User
{
    public class LoginDto
        {
            public string username { get; set; }
            public string passwordHash { get; set; }
        }
}