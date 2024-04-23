using Microsoft.AspNetCore.Http;
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

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var newUser = await _userService.UserSignUpAsync(signUpDto);
            
            return Ok(newUser);
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


        [HttpPatch("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto request)
        {
            var verifyOtpCode = await _userService.VerifyOtpAsync(request.Email, request.Otp);
            return Ok(verifyOtpCode);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var forgotPwdToken = await _userService.ForgotPassword(email);

            return Ok(forgotPwdToken);
        }

        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
        {
            var resetPwdStatus = await _userService.ResetPassword(email, token, newPassword);

            return Ok(resetPwdStatus);
        }

        [HttpPatch("Update-Users-Profile")]
        public async Task<IActionResult> UpdateUserProfile(Guid id, UpdateUserProfileDto userProfileDto)
        {
            var updateUser = await _userService.UpdateUserProfile(id, userProfileDto);
            return Ok(updateUser);
        }
    }
}
