using Blazored.LocalStorage;
using Kaptu.DLL.DTO;
using Kaptu.Web.Extensions;
using Kaptu.Web.Services.Interface;
using System.Text;
using System.Text.Json;

namespace Kaptu.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly CustomAuthenticationProvider _authProvider;

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            CustomAuthenticationProvider authProvider)
        {
            _http = httpClient;
            _localStorage = localStorage;
            _authProvider = authProvider;

            _http.BaseAddress =
                new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
        }

        public async Task<bool> SendMailOtp(string mail)
        {
            var response = await _http.PostAsync(
                $"/api/Auth/send-otp?email={Uri.EscapeDataString(mail)}",
                null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> VerifyOtpCode(long? code)
        {
            var userJson =
                await _localStorage.GetItemAsync<string>("userToRegister");

            if (string.IsNullOrWhiteSpace(userJson))
                return false;

            var user = JsonSerializer.Deserialize<UserDTO>(userJson);

            if (user is null)
                return false;

            var response = await _http.PostAsync(
                $"/api/Auth/verify-otp?email={Uri.EscapeDataString(user.Email)}&code={code}",
                null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> VerifyOtpCodeWithEmail(ChangePasswordDTO dto)
        {
            var email = await GetLocalStorage("UserEmailChangePassword");

            if (string.IsNullOrWhiteSpace(email))
                return false;

            var response = await _http.PostAsync(
                $"/api/Auth/verify-otp?email={Uri.EscapeDataString(email)}&code={dto.Code}",
                null);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdatePassword(ChangePasswordDTO dto)
        {
            dto.Email = await GetLocalStorage("UserEmailChangePassword");
            var response =
                await _http.PostAsJsonAsync("/api/User/update-password", dto);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> Authenticate(LoginDTO dto)
        {
            var response =
                await _http.PostAsJsonAsync("/api/Auth/authenticate", dto);

            if (!response.IsSuccessStatusCode)
                return false;

            var token = await response.Content.ReadAsStringAsync();

            await SetLocalStorage("authToken", token);

            dto.Token = token;

            await _authProvider.MarkUserAsAuthenticated(dto);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _authProvider.MarkUserAsLoggedOut();
        }

        public async Task SetUserLocalStorage(UserDTO dto)
        {
            await _localStorage.SetItemAsync("userToRegister", dto);
        }

        public async Task SetLocalStorage(string key, string value)
        {
            await _localStorage.SetItemAsync(key, value);
        }

        public async Task<string?> GetLocalStorage(string key)
        {
            return await _localStorage.GetItemAsync<string>(key);
        }
    }
}
