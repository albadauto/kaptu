using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movvi.ApiService.Commands.CreatePremiumUser;
using Movvi.ApiService.Queries.Plans.GetPlanByPriceId;
using Movvi.ApiService.Queries.Plans.GetPlans;
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
        private readonly IMediator _mediator;
        public StripeWebHookController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
                        var subscriptionService = new SubscriptionService();
                        var subscription = subscriptionService.Get(session.SubscriptionId);
                        var priceId = subscription.Items.Data[0].Price.Id;
                        Console.WriteLine($"StripePriceId: {priceId}");
                        if (session == null)
                            return BadRequest();

                        var clientReferenceId = session.ClientReferenceId;
                        var paymentIntentId = session.PaymentIntentId;
                        var customerEmail = session.CustomerDetails?.Email;
                        Console.WriteLine($"💰 Pagamento concluído!");
                        Console.WriteLine($"ClientReferenceId: {clientReferenceId}");
                        Console.WriteLine($"PaymentIntent: {paymentIntentId}");
                        Console.WriteLine($"Email: {customerEmail}");

                        var plan = await _mediator.Send(new GetPlanByPriceIdQuery(priceId));
                        Console.WriteLine($"Plano selecionado: {plan.Name}");
                        await _mediator.Send(new CreatePremiumUserCommand(0, int.Parse(session.ClientReferenceId), plan.Id, DateTime.Now.AddMonths(1),DateTime.Now, true));
                        Console.WriteLine($"Webhook executado");
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