using Blazored.LocalStorage;
using Movvi.DLL.DTO;
using Movvi.Web.Services.Interface;
using System.Net.Http.Json;
using System.Text.Json;

namespace Movvi.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public UserService(
        HttpClient httpClient,
        ILocalStorageService localStorageService)
    {
        _http = httpClient;
        _localStorage = localStorageService;

        _http.BaseAddress =
            new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
    }

    public async Task<bool> AddUser()
    {
        var userJson =
            await _localStorage.GetItemAsync<string>("userToRegister");

        if (string.IsNullOrWhiteSpace(userJson))
            return false;

        var dto = JsonSerializer.Deserialize<UserDTO>(userJson);

        if (dto is null)
            return false;

        var planId =
            await _localStorage.GetItemAsync<int>("planId");

        dto.PlanId = planId;

        var response =
            await _http.PostAsJsonAsync("/api/User/create-user", dto);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> IsUserExistsByMail(string email)
    {
        var response = await _http.GetAsync(
            $"/api/User/get-user-by-email?email={Uri.EscapeDataString(email)}");

        if (!response.IsSuccessStatusCode)
            return false;

        return true;
    }
}