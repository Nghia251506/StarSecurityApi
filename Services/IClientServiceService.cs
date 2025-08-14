using StarSecurityApi.Dtos.ClientService;

namespace StarSecurityApi.Services
{
    public interface IClientServiceService
    {
        Task<IEnumerable<ClientServiceReadDto>> GetAllAsync();
        Task<ClientServiceReadDto?> GetByIdAsync(int id);
        Task<ClientServiceReadDto> CreateAsync(ClientServiceCreateDto dto);
        Task<bool> UpdateAsync(int id, ClientServiceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
