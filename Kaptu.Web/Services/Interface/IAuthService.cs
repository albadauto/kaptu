using Kaptu.DLL.DTO;

namespace Kaptu.Web.Services.Interface
{
    public interface IAuthService
    {
        public Task<bool> SendMailOtp(string mail);
        public Task SetUserLocalStorage(UserDTO dto);
        public Task<bool> VerifyOtpCode(long? code);

    }
}
