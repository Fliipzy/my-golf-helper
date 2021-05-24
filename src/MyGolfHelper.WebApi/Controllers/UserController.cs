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
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users.Any())
            {
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(userDtos);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<IActionResult> GetUser(uint id)
        {
            var user = await _userService.FindUserAsync(id);

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }

            return NoContent();
        }
    }
}
