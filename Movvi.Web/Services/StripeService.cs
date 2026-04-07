using Movvi.DLL.DTO;
using Movvi.Web.Services.Interface;

namespace Movvi.Web.Services
{
    public class StripeService(HttpClient httpClient) : IStripeService
    {
        public readonly HttpClient _httpClient = httpClient;

        public async Task<string> CreateCheckoutSession(int userId)
        {
            PremiumUsersDTO dto = new PremiumUsersDTO
            {
                UserId = userId
            };
            var response = await _httpClient.PostAsJsonAsync("/api/Stripe/create-checkout", dto);
            if (response.IsSuccessStatusCode)
            {
                var url = await response.Content.ReadAsStringAsync();
                return url;
            }

            return string.Empty;
        }
    }
}
