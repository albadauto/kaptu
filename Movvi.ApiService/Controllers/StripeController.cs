using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movvi.ApiService.Queries.Plans.GetPlans;
using Movvi.DLL.DTO;
using Stripe.Checkout;

namespace Movvi.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StripeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(PremiumUsersDTO dto)
        {
            var plan = await _mediator.Send(new GetPlansQuery(dto.Plan));
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "subscription",
                ClientReferenceId = dto.UserId.ToString(),
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = plan.StripePriceId, 
                        Quantity = 1
                    }
                },
                SuccessUrl = "https://seusite.com/sucesso?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://seusite.com/cancelado",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(new { sessionId = session.Url });
        }
    }
}
