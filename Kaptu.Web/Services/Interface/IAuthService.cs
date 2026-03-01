using Kaptu.DLL.DTO;

namespace Kaptu.Web.Services.Interface
{
    public interface IAuthService
    {
        public Task<bool> SendMailOtp(string mail);
        public Task SetUserLocalStorage(UserDTO dto);
        public Task<bool> VerifyOtpCode(long? code);
        public Task<bool> Authenticate(LoginDTO login);
        public Task<bool> VerifyOtpCodeWithEmail(ChangePasswordDTO dto);
        public Task<bool> UpdatePassword(ChangePasswordDTO NewPassword);
        public Task SetLocalStorage(string key, string value);
        public Task<string> GetLocalStorage(string key);
        public Task Logout();

    }
}
