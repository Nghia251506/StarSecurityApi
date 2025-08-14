using StarSecurityApi.DTOs;

namespace StarSecurityApi.Service
{
    public interface IAuthRoleService
    {
        Task<IEnumerable<AuthRoleReadDto>> GetAllAsync();
        Task<AuthRoleReadDto?> GetByIdAsync(int id);
        Task<AuthRoleReadDto> CreateAsync(AuthRoleCreateDto dto);
        Task<bool> UpdateAsync(int id, AuthRoleUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
