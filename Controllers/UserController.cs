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

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]

        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllSync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _userService.GetByIdAsync(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newEmp = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newEmp.Id }, newEmp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var result = await _userService.UpdateAsync(id, user);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}