using Movvi.ApiService.Config;
using Movvi.ApiService.Queries.Parameters.GetParameter;
using Movvi.ApiService.Queries.User.GetUserByMail;
using Movvi.ApiService.Repository.Interfaces;
using Movvi.DLL.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Movvi.DLL.DTO.Output;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _authRepository;
        public readonly IMediator _mediator;
        public AuthController(IAuthRepository authRepository, IMediator mediator)
        {
            _authRepository = authRepository;
            _mediator = mediator;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromQuery] string email)
        {
            try
            {
                var code = new Random().Next(100000, 999999).ToString();
                await _authRepository.AddOtp(email, code);
                var mail = await ConfigureEmailText(code);
                Movvi.Helper.EmailHelper.SendMail(email, mail, "Código Movvi");
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

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<AuthOut>> Authenticate([FromBody] GetUserByEmailPasswordQuery query)
        {
            try
            {
                var user = await _mediator.Send(query);
                if (user.Email != null)
                {
                   if(BCrypt.Net.BCrypt.Verify(query.Password, user.Password))
                    {
                        var token = JwtConfig.GenerateToken(user);
                        AuthOut authOut = new AuthOut
                        {
                            UserId = user.Id,
                            Token = token,
                        };
                        return Ok(authOut);
                    }
                    else
                    {
                        return BadRequest(new { Message = "Invalid credentials" });
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during authentication", Details = ex.Message });
            }
        }

        private async Task<string> ConfigureEmailText(string code)
        {
            GetParameterQuery query = new("EMAIL_TEMPLATE_DEFAULT");
            var result = await _mediator.Send(query);
            return result.Value.Replace("{{TITULO_DA_MENSAGEM}}", "Código de ativação")
                .Replace("{{MENSAGEM}}", $"Não compartilhe o código com ninguém! Seu código é: {code}");
        }
    }
}
