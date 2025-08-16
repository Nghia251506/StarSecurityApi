using StarSecurityApi.Dtos.Employee;

namespace StarSecurityApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> GetAllAsync();
        Task<EmployeeReadDto?> GetByIdAsync(int id);
        Task<EmployeeReadDto> CreateAsync(EmployeeCreateDto dto);
        Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
