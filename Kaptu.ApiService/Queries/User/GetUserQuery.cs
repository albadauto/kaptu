using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Queries.User
{
    public record GetUserQuery : IRequest<List<UserDTO>>
    {
    }
}
