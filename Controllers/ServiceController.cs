using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;
        public ServiceController(IServiceService service) => _service = service;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _service.GetByIdAsync(id);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateDto dto)
        {
            var s = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceUpdateDto dto)
        {
            return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
