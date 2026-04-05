using Movvi.DLL.DTO;

namespace Movvi.Web.Services.Interface
{
    public interface IUserService
    {
        public Task<bool> AddUser();
        public Task<bool> IsUserExistsByMail(string email);
    }
}
