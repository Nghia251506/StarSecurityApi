using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.VacancyApplication;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyApplicationController : ControllerBase
    {
        private readonly IVacancyApplicationService _service;
        public VacancyApplicationController(IVacancyApplicationService service) => _service = service;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var app = await _service.GetByIdAsync(id);
            return app == null ? NotFound() : Ok(app);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VacancyApplicationCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VacancyApplicationUpdateDto dto)
            => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
