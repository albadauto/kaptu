using Movvi.ApiService.Commands.Auth.UpdatePassword;
using Movvi.ApiService.Commands.Users.AddUser;
using Movvi.ApiService.Queries.User.GetUser;
using Movvi.ApiService.Queries.User.GetUserByMail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        public IMediator _mediator = mediator;

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating user", Details = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-user-by-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserByMailQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result.Email == null)
                {
                    return NotFound(new { Message = "User not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving user", Details = ex.Message });
            }
        }

        [HttpPost]
        [Route("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result)
                {
                    return Ok(new { Message = "Password updated successfully" });
                }
                else
                {
                    return BadRequest(new { Message = "Failed to update password" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating password", Details = ex.Message });
            }
        }
    }
}
