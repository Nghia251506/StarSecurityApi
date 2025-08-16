using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.Employee;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service) => _service = service;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _service.GetByIdAsync(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto dto)
        {
            var emp = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
