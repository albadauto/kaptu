using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Queries.User.GetUser
{
    public record GetUserQuery : IRequest<List<UserDTO>>
    {
    }
}
