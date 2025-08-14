using StarSecurityApi.Dtos;
using StarSecurityApi.DTOs;
using StarSecurityApi.Models;
namespace StarSecurityApi.Service
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllSync();
        Task<Grade?> GetByIdAsync(int id);
        Task<GradeReadDto> CreateAsync(GradeCreateDto dto);
        Task<bool> UpdateAsync(int id, Grade grade);
        Task<bool> DeleteAsync(int id);
    }
}