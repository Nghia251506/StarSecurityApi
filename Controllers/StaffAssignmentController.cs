using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos.StaffAssignment;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAssignmentController : ControllerBase
    {
        private readonly IStaffAssignmentService _service;
        public StaffAssignmentController(IStaffAssignmentService service) => _service = service;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sa = await _service.GetByIdAsync(id);
            return sa == null ? NotFound() : Ok(sa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StaffAssignmentCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StaffAssignmentUpdateDto dto)
            => await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
