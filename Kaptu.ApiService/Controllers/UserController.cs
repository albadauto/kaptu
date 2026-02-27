using Kaptu.ApiService.Commands.Users.AddUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaptu.ApiService.Controllers
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
    }
}
