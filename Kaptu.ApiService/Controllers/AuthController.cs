using Kaptu.ApiService.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaptu.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromQuery] string email)
        {
            try
            {
                var code = new Random().Next(100000, 999999).ToString();
                await _authRepository.AddOtp(email, code);
                Kaptu.Helper.EmailHelper.SendMail(email, $"Your OTP code is: {code}", "Kaptu OTP Code");
                return Ok(new { Message = "OTP sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while sending OTP", Details = ex.Message });
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromQuery] string email, [FromQuery] string code)
        {
            try
            {
                var isValid = await _authRepository.VerifyOtp(email, code);
                if (isValid)
                {
                    return Ok(new { Message = "OTP verified successfully" });
                }
                else
                {
                    return BadRequest(new { Message = "Invalid or expired OTP" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while verifying OTP", Details = ex.Message });
            }
        }
    }
}
