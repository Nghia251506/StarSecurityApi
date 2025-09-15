using Microsoft.AspNetCore.Mvc;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Services;
using StarSecurityApi.Service;
using StarSecurityApi.Dtos;
using StarSecurityApi.Dtos.User;
using System.IdentityModel.Tokens.Jwt;
using StarSecurityApi.Helpers;

namespace StarSecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly JwtHelper _jwtHelper;

        public UserController(IUserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto.username, loginDto.passwordHash);
            if (user == null)
                return BadRequest("Invalid username or password");

            var token = _jwtHelper.GenerateToken(user); // token có thể encode role

            return Ok(new
            {
                token,
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    roleId = user.AuthRoleId,
                    roleName = user.AuthRole?.Name,
                    employeeCode = user.Employee?.EmployeeCode,
                    employeeName = user.Employee?.FullName,
                    employeDeaprtment = user.Employee?.Department?.Name,
                    employeeGrade = user.Employee?.Grade?.Name,
                    employeePhone = user.Employee?.Phone,
                    employeeAddress = user.Employee?.Address,
                    employeeEducation = user.Employee?.Education,
                    employeeJobTile = user.Employee?.Job
                }
            });
        }

    }
}