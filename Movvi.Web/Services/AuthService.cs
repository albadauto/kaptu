using Blazored.LocalStorage;
using Movvi.DLL.DTO;
using Movvi.DLL.DTO.Output;
using Movvi.Web.Extensions;
using Movvi.Web.Services.Interface;
using System.Text;
using System.Text.Json;

namespace Movvi.Web.Services
{
    public class AuthService(
        HttpClient httpClient,
        ILocalStorageService localStorage,
        CustomAuthenticationProvider authProvider) : IAuthService
    {
        private readonly HttpClient _http = httpClient;
        private readonly ILocalStorageService _localStorage = localStorage;
        private readonly CustomAuthenticationProvider _authProvider = authProvider;

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

        public async Task<bool> IsUserExistsByMail(string email)
        {
            var response = await _http.GetAsync(
                $"/api/User/get-user-by-email?email={Uri.EscapeDataString(email)}");
            return response.IsSuccessStatusCode;
        }


        public async Task<AuthOut> Authenticate(LoginDTO dto)
        {
            var response = await _http.PostAsJsonAsync("/api/Auth/authenticate", dto);

            if (!response.IsSuccessStatusCode)
                return null;

            var auth = await response.Content.ReadFromJsonAsync<AuthOut>();

            await SetLocalStorage("authToken", auth.Token);

            dto.Token = auth.Token;

            await _authProvider.MarkUserAsAuthenticated(dto);

            return auth;
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
