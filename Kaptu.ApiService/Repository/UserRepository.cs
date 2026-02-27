using Kaptu.ApiService.Repository.Interfaces;
using Kaptu.DLL.DTO;
using Kaptu.DLL.Models;

namespace Kaptu.ApiService.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly SqlServerContext _context;
        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }
        public async Task AddUser(UserDTO dto)
        {
           
        }
    }
}
