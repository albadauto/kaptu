using Kaptu.DLL.DTO;
using Kaptu.DLL.DTO.Output;
using Kaptu.DLL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Stripe;
using Stripe.Checkout;
using Stripe.V2.Core;

namespace Kaptu.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IDatabase _redis;

        public PaymentsController(IDatabase redis)
        {
            _redis = redis;
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
                        Price = ((Kaptu.DLL.Enums.Plan)dto.Plan).GetDescription(),
                        Quantity = 1,
                    },
                },

                SuccessUrl = "https://meusite.com/sucesso?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://meusite.com/cancelado",
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            await _redis.SetAddAsync($"{dto.UserId}_checkout_id", session.Id);
            return Ok(new CreatePaymentOut { CheckoutId = session.Id, Url = session.Url });
        }

        [HttpPost]
        [Route("verify-payment")]
        public async Task<IActionResult> VerifyPayment([FromQuery] int UserId)
        {
            var checkoutId = (await _redis.SetPopAsync($"{UserId}_checkout_id")).ToString();
            if (string.IsNullOrEmpty(checkoutId))
            {
                return BadRequest(new { Message = "No pending payment found for this user." });
            }

            var service = new SessionService();
            Session session = await service.GetAsync(checkoutId);
            if (session.PaymentStatus == "paid")
            {
                return Ok(new { Message = "Payment verified successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Payment not completed yet." });
            }
        }

        [HttpPost]
        [Route("cancel-payment")]
        public async Task<IActionResult> CancelPayment()
        {
            return Ok();
        }

    }
}
