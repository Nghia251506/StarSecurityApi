using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Testimonial;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        public TestimonialService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<TestimonialReadDto>> GetAllAsync()
        {
            return await _context.Testimonials
                .Include(t => t.Client)
                .Select(t => new TestimonialReadDto
                {
                    Id = t.Id,
                    ClientId = t.ClientId,
                    ClientName = t.Client != null ? t.Client.Name : null,
                    AuthorName = t.AuthorName,
                    AuthorTitle = t.AuthorTitle,
                    Content = t.Content,
                    Visible = t.Visible,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<TestimonialReadDto?> GetByIdAsync(int id)
        {
            var t = await _context.Testimonials
                .Include(c => c.Client)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (t == null) return null;

            return new TestimonialReadDto
            {
                Id = t.Id,
                ClientId = t.ClientId,
                ClientName = t.Client?.Name,
                AuthorName = t.AuthorName,
                AuthorTitle = t.AuthorTitle,
                Content = t.Content,
                Visible = t.Visible,
                CreatedAt = t.CreatedAt
            };
        }

        public async Task<TestimonialReadDto> CreateAsync(TestimonialCreateDto dto)
        {
            var t = new Testimonial
            {
                ClientId = dto.ClientId,
                AuthorName = dto.AuthorName,
                AuthorTitle = dto.AuthorTitle,
                Content = dto.Content,
                Visible = dto.Visible
            };

            _context.Testimonials.Add(t);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(t.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, TestimonialUpdateDto dto)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null) return false;

            t.ClientId = dto.ClientId;
            t.AuthorName = dto.AuthorName;
            t.AuthorTitle = dto.AuthorTitle;
            t.Content = dto.Content;
            t.Visible = dto.Visible;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var t = await _context.Testimonials.FindAsync(id);
            if (t == null) return false;

            _context.Testimonials.Remove(t);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
