using StarSecurityApi.Dtos.ServiceRequest;

namespace StarSecurityApi.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequestReadDto>> GetAllAsync();
        Task<ServiceRequestReadDto?> GetByIdAsync(int id);
        Task<ServiceRequestReadDto> CreateAsync(ServiceRequestCreateDto dto);
        Task<bool> UpdateAsync(int id, ServiceRequestUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
