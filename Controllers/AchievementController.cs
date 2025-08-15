using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.Achievement;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _service;
        public AchievementController(IAchievementService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var achievement = await _service.GetByIdAsync(id);
            return achievement == null ? NotFound() : Ok(achievement);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AchievementCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AchievementUpdateDto dto)
            => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
