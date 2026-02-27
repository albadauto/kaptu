using Kaptu.DLL.DTO;

namespace Kaptu.ApiService.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUser(UserDTO dto);
    }
}
