using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.ServiceRequest;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _service;
        public ServiceRequestController(IServiceRequestService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sr = await _service.GetByIdAsync(id);
            return sr == null ? NotFound() : Ok(sr);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequestCreateDto dto)
        {
            var sr = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = sr.Id }, sr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceRequestUpdateDto dto)
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
