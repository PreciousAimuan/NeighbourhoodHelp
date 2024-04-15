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
        public async Task<IActionResult> SignUp([FromForm] SignUpDto signUpDto)
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

        [HttpPatch("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto request)
        {
            var verifyOtpCode = await _userService.VerifyOtpAsync(request.Email, request.Otp);
            return Ok(verifyOtpCode);
        }


    }
}
