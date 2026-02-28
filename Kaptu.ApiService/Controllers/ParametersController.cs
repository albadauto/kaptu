using Kaptu.ApiService.Queries.Parameters.GetParameter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaptu.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParametersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/get-parameter")]
        public async Task<IActionResult> GetParameter([FromQuery] GetParameterQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result == null)
                {
                    return NotFound(new { Message = "Parameter not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving parameter", Details = ex.Message });
            }
        }
    }
}
