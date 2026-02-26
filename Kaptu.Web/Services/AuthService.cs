using Blazored.LocalStorage;
using Kaptu.DLL.DTO;
using Kaptu.Web.Services.Interface;

namespace Kaptu.Web.Services
{
    public class AuthService : IAuthService
    {
        public ILocalStorageService _localStorageService { get; set; }
        public AuthService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async Task<bool> SendMailOtp(string mail)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
            var response = await httpClient.PostAsync($"/api/Auth/send-otp?email={Uri.EscapeDataString(mail)}", null);
            return response.IsSuccessStatusCode;
        }


        public async Task SetUserLocalStorage(UserDTO dto)
        {
            var userJson = System.Text.Json.JsonSerializer.Serialize(dto);
            await _localStorageService.SetItemAsync<string>("userToRegister", userJson);
        }

        public async Task<bool> VerifyOtpCode(long? code)
        {
            var userJson = await _localStorageService.GetItemAsync<string>("userToRegister");
            var user = System.Text.Json.JsonSerializer.Deserialize<UserDTO>(userJson);
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
            var response = await httpClient.PostAsync($"/api/Auth/verify-otp?email={Uri.EscapeDataString(user!.Email)}&code={code}", null);
            return response.IsSuccessStatusCode;
        }
    }
}
