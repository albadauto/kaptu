using Movvi.ApiService.Commands.CreatePremiumUser;
using Movvi.DLL.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PremiumUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-premium-user")]
        public async Task<IActionResult> CreatePremiumUser([FromBody] CreatePremiumUserCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
    }
}
