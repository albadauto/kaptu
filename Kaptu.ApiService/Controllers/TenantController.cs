using Kaptu.ApiService.Commands.Tenants.CreateTenant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaptu.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController(IMediator mediator): ControllerBase
    {
        public readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("/create-tenant")]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTenantCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
