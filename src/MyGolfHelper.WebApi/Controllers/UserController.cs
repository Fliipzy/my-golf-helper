using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGolfHelper.Models;
using MyGolfHelper.Models.Dtos;
using MyGolfHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGolfHelper.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User, long> _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService<User, long> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (!users.Any())
            {
                return NoContent();
            }

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var user = await _userService.FindUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(NewUserRequestDto newUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedUser = _mapper.Map<User>(newUserDto);
            var user = await _userService.CreateUser(mappedUser);
            var mappedUserDto = _mapper.Map<UserDto>(user);

            return Ok(mappedUserDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(long id, UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = _mapper.Map<User>(userDto);
            updatedUser.Id = id;

            var updatedResult = await _userService.UpdateUserAsync(updatedUser);

            if (!updatedResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
