using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Text;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebHookController : ControllerBase
    {
        private const string EndpointSecret = "whsec_1a150eb4c2c07b8c1c30b0820c03bfd342de7d30d1ff78ca7185cdccc6e962d3";

        [HttpPost]
        public async Task<IActionResult> Handle()
        {
            Request.EnableBuffering();

            var json = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            Request.Body.Position = 0;

            var signatureHeader = Request.Headers["Stripe-Signature"].ToString();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    signatureHeader,
                    EndpointSecret,
                    throwOnApiVersionMismatch: false

                );

                Console.WriteLine($"✅ Evento: {stripeEvent.Type}");

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ ERRO DETALHADO:");
                Console.WriteLine(ex.ToString());

                return BadRequest();
            }
        }
    }
}
