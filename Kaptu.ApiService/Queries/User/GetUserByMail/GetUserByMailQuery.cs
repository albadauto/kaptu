using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Queries.User.GetUserByMail
{
    public record GetUserByMailQuery(string Email) : IRequest<UserDTO>
    {
    }
}
