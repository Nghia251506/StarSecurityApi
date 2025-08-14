using StarSecurityApi.Dtos.Service;

namespace StarSecurityApi.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceReadDto>> GetAllAsync();
        Task<ServiceReadDto?> GetByIdAsync(int id);
        Task<ServiceReadDto> CreateAsync(ServiceCreateDto dto);
        Task<bool> UpdateAsync(int id, ServiceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
