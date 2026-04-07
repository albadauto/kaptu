using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movvi.ApiService.Queries.Parameters.GetParameter;
using Movvi.ApiService.Queries.Plans.GetPlans;
using Movvi.ApiService.Queries.User.GetUserById;
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
        [Route("create-checkout")]
        public async Task<IActionResult> CreateCheckoutSession(PremiumUsersDTO dto)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(dto.UserId));
            var plan = await _mediator.Send(new GetPlansQuery(user.PlanId));
            var parameter = await _mediator.Send(new GetParameterQuery("BASEURL"));
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
                SuccessUrl = $"{parameter.Value}/payment-confirmation/success",
                CancelUrl = $"{parameter.Value}/payment-confirmation/error",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(session.Url);
        }
    }
}
