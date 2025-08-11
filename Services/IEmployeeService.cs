using StarSecurityApi.DTOs;

namespace StarSecurityApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<EmployeeReadDto> CreateAsync(EmployeeCreateDto dto);
        Task<bool> UpdateAsync(int id, Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
