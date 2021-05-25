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
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService<User, long> _userService;

        public AuthenticationController(
            IAuthenticationService authenticationService, 
            IUserService<User, long> userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginRequestDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundUser = await _userService.FindUserByEmailAsync(userLoginDto.Email);

            if (foundUser == null)
            {
                return UnprocessableEntity();
            }

            var authenticated = await _authenticationService.VerifyUserPassword(userLoginDto.Password, foundUser.Password);

            if (!authenticated)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
