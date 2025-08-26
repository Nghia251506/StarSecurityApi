using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Dtos.ServicePackage;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicePackageController : ControllerBase
    {
        private readonly IServicePackageService _servicepackage;

        public ServicePackageController(IServicePackageService servicepackage) => _servicepackage = servicepackage;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => Ok(await _servicepackage.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _servicepackage.GetByIdAsync(id);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicePackageCreateDto dto)
        {
            var s = await _servicepackage.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServicePackageUpdateDto dto)
        {
            return await _servicepackage.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _servicepackage.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}