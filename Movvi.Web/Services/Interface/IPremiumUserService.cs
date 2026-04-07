using Movvi.DLL.DTO;

namespace Movvi.Web.Services.Interface
{
    public interface IPremiumUserService
    {
        public Task<PremiumUsersDTO> GetPremiumUser(int userId);
    }
}
