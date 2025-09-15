using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;

namespace StarSecurityApi.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context; //Declaration

        public UserService(AppDbContext context) //contructor
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllSync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Username == username);
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _context.Users
                .Include(u => u.AuthRole)
                .Include(u => u.Employee)
                .ThenInclude(e => e.Department)
                .Include(u => u.Employee)
                .ThenInclude(e => e.Grade)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            // kiểm tra password hash
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var user = new User
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password_hash),
                AuthRoleId = dto.Auth_role_id.HasValue ? dto.Auth_role_id.Value : 5,
                LastLogin = dto.Last_login,
                CreatedAt = DateTime.Now,
                EmployeeId = dto.Employee_id.HasValue ? dto.Employee_id.Value : null
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserReadDto
            {
                Id = user.Id,
                Employee_id = user.EmployeeId,
                Username = user.Username,
                Password_hash = user.PasswordHash,
                Auth_role_id = user.AuthRoleId,
                Last_login = user.LastLogin,
                CreateAt = user.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, User user)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return false;

            // existing.EmployeeId = user.EmployeeId;
            existing.Username = user.Username;
            existing.PasswordHash = user.PasswordHash;
            // existing.AuthRoleId = user.AuthRoleId;
            // existing.LastLogin = user.LastLogin;
            // existing.CreatedAt = user.CreatedAt;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _context.Users.FindAsync(id);
            if (emp == null) return false;

            _context.Users.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}