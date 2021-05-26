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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtService<User> _jwtService;
        private readonly IUserService<User, long> _userService;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IJwtService<User> jwtService,
            IUserService<User, long> userService)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/authenticate")]
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
            var accessToken = _jwtService.GenerateToken(foundUser);
            return Ok(new { accessToken = accessToken });
        }
    }
}
