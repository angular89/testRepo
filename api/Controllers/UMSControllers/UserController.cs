using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UMS;
using api.Models;
using api.Services.UMService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers.UMSControllers
{
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        public UserController(DataContext context, IUserService userService)
        {
            _userService = userService;
            _context = context;

        }
        [HttpGet("GetById/{identity}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetUser(string identity)
        {
            return Ok(await _userService.GetUserByUsername(identity));
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<UserDto>>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UpdateUser(UpdateUserDto updateUser)
        {
            if (await UserExists(updateUser.Username.ToLower())) return BadRequest("Username is taken !");
            return Ok(await _userService.UpdateUser(updateUser));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<UserDto>>> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}