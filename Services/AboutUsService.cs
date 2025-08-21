using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.AboutUs;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Models;
using StarSecurityApi.Service;

namespace StarSecurityApi.Services
{
    public class AboutUsService : IAboutUsService
    {
        private readonly AppDbContext _context;
        public AboutUsService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<AboutUsReadDto>> GetAllSync()
        {
            return await _context.AboutUses
                .Select(ab => new AboutUsReadDto
                {
                    SectionTitle = ab.SectionTitle,
                    SectionContent = ab.SectionContent,
                    ImageUrl = ab.ImageUrl,
                    VideoUrl = ab.VideoUrl

                })
                .ToListAsync();
        }

        public async Task<AboutUsReadDto?> GetByIdAsync(int id)
        {
            var s = await _context.AboutUses.FindAsync(id);
            if (s == null) return null;
            return new AboutUsReadDto
            {
                SectionTitle = s.SectionTitle,
                SectionContent = s.SectionContent,
                ImageUrl = s.ImageUrl,
                VideoUrl = s.VideoUrl
            };
        }

        public async Task<AboutUsReadDto> CreateAsync(AboutUsCreateDto dto)
        {
            var s = new AboutUs
            {
                SectionTitle = dto.SectionTitle,
                SectionContent = dto.SectionContent,
                VideoUrl = dto.VideoUrl,
                ImageUrl = dto.ImageUrl,
            };
            _context.AboutUses.Add(s);
            await _context.SaveChangesAsync();
            return (await GetByIdAsync(s.Id))!;
        }
        
        public async Task<bool> UpdateAsync(int id, AboutUsUpdateDto dto)
        {
            var s = await _context.AboutUses.FindAsync(id);
            if (s == null) return false;

            s.SectionTitle = dto.SectionTitle;
            s.SectionContent = dto.SectionContent;
            s.ImageUrl = dto.ImageUrl;
            s.VideoUrl = dto.VideoUrl;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var s = await _context.AboutUses.FindAsync(id);
            if (s == null) return false;
            _context.AboutUses.Remove(s);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}