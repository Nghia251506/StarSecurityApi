using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Services;
using StarSecurityApi.Service;
using StarSecurityApi.Dtos;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var grades = await _gradeService.GetAllSync();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _gradeService.GetByIdAsync(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GradeCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEmp = await _gradeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newEmp.Id }, newEmp);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] Grade grade)
        {
            var result = await _gradeService.UpdateAsync(id, grade);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gradeService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}