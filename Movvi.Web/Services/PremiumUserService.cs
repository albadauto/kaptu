using Movvi.DLL.DTO;
using Movvi.Web.Services.Interface;

namespace Movvi.Web.Services
{
    public class PremiumUserService(HttpClient client) : IPremiumUserService
    {
        private readonly HttpClient _http = client;
        public async Task<PremiumUsersDTO> GetPremiumUser(int userId)
        {
            var premiumUser = await _http.GetAsync($"/api/PremiumUser/get-premium-user/{userId}");
            if(premiumUser.IsSuccessStatusCode)
            {
                var premiumUserDTO = await premiumUser.Content.ReadFromJsonAsync<PremiumUsersDTO>();
                return premiumUserDTO!;
            }

            return null;
        }
    }
}
