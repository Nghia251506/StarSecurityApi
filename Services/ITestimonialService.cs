using StarSecurityApi.Dtos.Testimonial;

namespace StarSecurityApi.Services
{
    public interface ITestimonialService
    {
        Task<IEnumerable<TestimonialReadDto>> GetAllAsync();
        Task<TestimonialReadDto?> GetByIdAsync(int id);
        Task<TestimonialReadDto> CreateAsync(TestimonialCreateDto dto);
        Task<bool> UpdateAsync(int id, TestimonialUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
