using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.AboutUs;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Service;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _about;
        public AboutUsController(IAboutUsService about) => _about = about;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => Ok(await _about.GetAllSync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _about.GetByIdAsync(id);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutUsCreateDto dto)
        {
            var s = await _about.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = s.Id}, s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AboutUsUpdateDto dto)
        {
            return await _about.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _about.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}