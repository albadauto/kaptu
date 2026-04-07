using MediatR;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.User.GetUserById
{
    public record GetUserByIdQuery(int userId) : IRequest<UserDTO>
    {
    }
}
