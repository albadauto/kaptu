using Movvi.DLL.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace Movvi.Web.Extensions
{
    public class CustomAuthenticationProvider : AuthenticationStateProvider
    {
        private readonly ProtectedLocalStorage _localStorage;
        public CustomAuthenticationProvider(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var result = await _localStorage.GetAsync<string>("authToken");

            if (result.Success && !string.IsNullOrEmpty(result.Value))
            {
                var identity = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("AuthToken", result.Value)
                }, "Custom authentication");
                var user = new System.Security.Claims.ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            else
            {
                var anonymous = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }
        }

        public async Task MarkUserAsAuthenticated(LoginDTO dto)
        {
            await _localStorage.SetAsync("authToken", dto.Token);
            await _localStorage.SetAsync("UserId", dto.UserId);
            var identity = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim("AuthToken", dto.Token)
            }, "Custom authentication");
            var user = new System.Security.Claims.ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorage.DeleteAsync("authToken");
            var anonymous = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }

        public async Task<string> GetAuthToken()
        {
            var result = await _localStorage.GetAsync<string>("authToken");
            return result.Success ? result.Value ?? string.Empty : string.Empty;
        }
        public async Task<int> GetUserId()
        {
            var result = await _localStorage.GetAsync<int>("IdUsuario");
            return result.Value;
        }
    }
}
