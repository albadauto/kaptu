using Movvi.DLL.DTO;

namespace Movvi.ApiService.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUser(UserDTO dto);
    }
}
