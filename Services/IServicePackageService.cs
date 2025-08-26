using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Dtos.ServicePackage;

namespace StarSecurityApi.Services
{
    public interface IServicePackageService
    {
        Task<IEnumerable<ServicePackageReadDto>> GetAllAsync();
        Task<ServicePackageReadDto?> GetByIdAsync(int id);
        Task<ServicePackageReadDto> CreateAsync(ServicePackageCreateDto dto);
        Task<bool> UpdateAsync(int id, ServicePackageUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}