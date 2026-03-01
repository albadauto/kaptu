using Kaptu.Web.Services;
using Kaptu.Web.Services.Interface;

namespace Kaptu.Web.Extensions
{
    public static class AddExtensionHttpClient
    {
        public static IServiceCollection AddHttpClientCustom(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress =
                    new Uri(Helpers.AppSettingsHelper.GetApiUrl("Service")!);
            });
            return services;
        }
    }
}
