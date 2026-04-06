using Movvi.Web.Helpers;
using Movvi.Web.Services;
using Movvi.Web.Services.Interface;

namespace Movvi.Web.Extensions
{
    public static class AddExtensionHttpClient
    {
        public static IServiceCollection AddHttpClientCustom(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(AppSettingsHelper.GetApiUrl("Service")!);
            });

            services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri(AppSettingsHelper.GetApiUrl("Service")!);
            });

            return services;
        }
    }
}
