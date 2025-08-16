using StarSecurityApi.Dtos;
using StarSecurityApi.DTOs;
using StarSecurityApi.Models;
namespace StarSecurityApi.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllSync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> LoginAsync(string username, string password);
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<bool> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}