using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.Vacancy;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _service;
        public VacancyController(IVacancyService service) => _service = service;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacancy = await _service.GetByIdAsync(id);
            return vacancy == null ? NotFound() : Ok(vacancy);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VacancyCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VacancyUpdateDto dto)
            => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
