using StarSecurityApi.Dtos;
using StarSecurityApi.DTOs;
using StarSecurityApi.DTOs;
using StarSecurityApi.Models;
namespace StarSecurityApi.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllSync();
        Task<User?> GetByIdAsync(int id);
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
        Task<bool> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}