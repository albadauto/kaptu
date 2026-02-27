using Blazored.LocalStorage;
using Kaptu.DLL.DTO;
using Kaptu.DLL.Models;
using Kaptu.Web.Services.Interface;
using System.Text;
using System.Text.Json;

namespace Kaptu.Web.Services
{
    public class UserService(ILocalStorageService localStorageService) : IUserService
    {
        public ILocalStorageService _localStorageService { get; set; } = localStorageService;
        public async Task<bool> AddUser()
        {
            var userLocalStorage = await _localStorageService.GetItemAsync<string>("userToRegister");
            var dto = JsonSerializer.Deserialize<UserDTO>(userLocalStorage!);
            dto!.Plan = await _localStorageService.GetItemAsync<int>("planId");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/User/create-user", content);
            return response.IsSuccessStatusCode;


        }
    }
}
