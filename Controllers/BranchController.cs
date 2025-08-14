using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Dtos;
using StarSecurityApi.Service;
using StarSecurityApi.Services;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _branchService;

        public BranchController(BranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchService.GetAllSync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null) return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateDto dto)
        {
            var newBranch = await _branchService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newBranch.Id }, newBranch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BranchUpdateDto dto)
        {
            var updated = await _branchService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _branchService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
