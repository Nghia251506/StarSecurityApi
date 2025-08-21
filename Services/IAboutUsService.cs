using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;
using System.ComponentModel;
using StarSecurityApi.Dtos.AboutUs;
namespace StarSecurityApi.Service
{
    public interface IAboutUsService
    {
        Task<IEnumerable<AboutUsReadDto>> GetAllSync();
        Task<AboutUsReadDto?> GetByIdAsync(int id);
        Task<AboutUsReadDto> CreateAsync(AboutUsCreateDto dto);
        Task<bool> UpdateAsync(int id, AboutUsUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}