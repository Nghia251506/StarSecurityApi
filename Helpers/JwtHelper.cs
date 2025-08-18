using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StarSecurityApi.Models;

namespace StarSecurityApi.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var secretKey = "f8G7hT3kLm9PqRs4UvWxYz1234567890AbCdEfGhIjKlMnOpQrStUvWxYz1234";
            var issuer = "StarSecurityApi";
            var audience = "StarSecurityClient";
            var expiresIn = 1;
            // int.Parse(_configuration["JwtSettings:ExpiresInHours"]);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("username", user.Username ?? ""),
                new Claim("isActive", user.IsActive.ToString()),
                new Claim("isAdmin", (user.AuthRoleId == 1).ToString()),
                new Claim("roleName", (user.AuthRole.Name ?? "")),
                new Claim("employeeCode", user.Employee?.EmployeeCode ?? ""),
                new Claim("employeeName", user.Employee?.FullName ?? ""),
                new Claim("employeeDepartment", user.Employee?.Department?.Name ?? ""),
                new Claim("employeeGrade", user.Employee?.Grade?.Name ?? ""),
                new Claim("employeePhone", user.Employee?.Phone ?? ""),
                new Claim("employeeAddress", user.Employee?.Address ?? ""),
                new Claim("employeeEducation", user.Employee?.Education ?? ""),
                new Claim("employeeJobTitle", user.Employee?.JobTitle ?? "")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddHours(expiresIn),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
