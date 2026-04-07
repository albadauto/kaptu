using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Task.FromResult<IActionResult>(Ok("API is healthy"));
        }
    }
}
