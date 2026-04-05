using Movvi.DLL.DTO;
using MediatR;

namespace Movvi.ApiService.Queries.User.GetUser
{
    public record GetUserQuery : IRequest<List<UserDTO>>
    {
    }
}
