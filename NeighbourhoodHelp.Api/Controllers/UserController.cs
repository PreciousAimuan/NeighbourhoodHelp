﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("user-sign-up")]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto userSignUpDto)
        {
            var newUser = await _userService.UserSignUpAsync(userSignUpDto);

            return Ok("Sign Up Successful. Please Check your email for an OTP");
        }
        [HttpGet("get-user-by-errandId")]
        public async Task<IActionResult> GetUserByErrandId(Guid errandId)
        {
            var userbyerrand = await _userService.GetUserByErrandIdAsync(errandId);

            return Ok(userbyerrand);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            //return result
            return Ok(await _userService.LoginService(loginDto));
        } 

    }
}
