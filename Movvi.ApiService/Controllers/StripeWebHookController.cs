using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Text;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebHookController : ControllerBase
    {
        private const string EndpointSecret = "whsec_UqCpLG5PKoBy3PJP2Tzp3V57vGdExR6a";

        [HttpPost]
        public async Task<IActionResult> Handle()
        {
            Request.EnableBuffering();

            var json = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            Request.Body.Position = 0;

            var signatureHeader = Request.Headers["Stripe-Signature"];

            Event stripeEvent;

            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    signatureHeader,
                    EndpointSecret,
                    throwOnApiVersionMismatch: false
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Erro ao validar assinatura:");
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            Console.WriteLine($"✅ Evento recebido: {stripeEvent.Type}");

            switch (stripeEvent.Type)
            {
                case "checkout.session.completed":
                    {
                        var session = stripeEvent.Data.Object as Session;

                        if (session == null)
                            return BadRequest();

                        var clientReferenceId = session.ClientReferenceId;
                        var paymentIntentId = session.PaymentIntentId;
                        var customerEmail = session.CustomerDetails?.Email;
                        Console.WriteLine($"💰 Pagamento concluído!");
                        Console.WriteLine($"ClientReferenceId: {clientReferenceId}");
                        Console.WriteLine($"PaymentIntent: {paymentIntentId}");
                        Console.WriteLine($"Email: {customerEmail}");

                        break;
                    }

                case "payment_intent.succeeded":
                    {
                        var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

                        Console.WriteLine($"💵 PaymentIntent confirmado: {paymentIntent.Id}");

                        break;
                    }

                case "checkout.session.expired":
                    {
                        var session = stripeEvent.Data.Object as Session;

                        Console.WriteLine($"⏰ Sessão expirou: {session.Id}");

                        break;
                    }

                default:
                    Console.WriteLine($"ℹ️ Evento não tratado: {stripeEvent.Type}");
                    break;
            }

            return Ok();
        }
    }
}