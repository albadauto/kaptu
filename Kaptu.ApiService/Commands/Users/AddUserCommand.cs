using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Commands.Users
{
    public record AddUserCommand(UserDTO dto) : IRequest<bool>
    {

    }
}
