using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;
using System.ComponentModel;
namespace StarSecurityApi.Service
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllSync();
        Task<Department?> GetByIdAsync(int id);
        Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto);
        Task<bool> UpdateAsync(int id, Department department);
        Task<bool> DeleteAsync(int id);
    }
}