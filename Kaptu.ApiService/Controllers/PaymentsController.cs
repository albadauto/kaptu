using Kaptu.DLL.DTO;
using Kaptu.DLL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Kaptu.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PaymentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PremiumUsersDTO dto)
        {
            var options = new SessionCreateOptions
            {
                Mode = "subscription",

                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = ((Kaptu.DLL.Enums.Plan)dto.Plan).GetDescription(), // preço recorrente criado no Stripe
                        Quantity = 1,
                    },
                },

                SuccessUrl = "https://meusite.com/sucesso?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://meusite.com/cancelado",
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return Ok(session.Url);
        }

        [HttpPost]
        [Route("verify-payment")]
        public async Task<IActionResult> VerifyPayment()
        {
            return Ok();
        }

        [HttpPost]
        [Route("cancel-payment")]
        public async Task<IActionResult> CancelPayment()
        {
            return Ok();
        }


    }
}
