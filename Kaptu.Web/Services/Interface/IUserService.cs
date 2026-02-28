using Kaptu.DLL.DTO;

namespace Kaptu.Web.Services.Interface
{
    public interface IUserService
    {
        public Task<bool> AddUser();
        public Task<bool> IsUserExistsByMail(string email);
    }
}
