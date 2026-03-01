using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Queries.User.GetUserByMail
{
    public record GetUserByEmailPasswordQuery(string Email, string Password) : IRequest<UserDTO>
    {
    }
}
