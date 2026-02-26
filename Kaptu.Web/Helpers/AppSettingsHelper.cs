namespace Kaptu.Web.Helpers
{
    public static class AppSettingsHelper
    {
        private static IConfiguration _configuration;
        private static IWebHostEnvironment _env;
        private static IHttpContextAccessor _httpContextAccessor;
        public static void Initialize(IConfiguration configuration, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public static string? GetApiUrl(string key)
        {
            return _env.IsDevelopment()
                ? _configuration[$"APIURLS_DEV:{key}"]
                : _configuration[$"APIURLS_PROD:{key}"];
        }
    }
}
