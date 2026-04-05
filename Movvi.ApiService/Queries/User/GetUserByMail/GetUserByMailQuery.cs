using Movvi.DLL.DTO;
using MediatR;

namespace Movvi.ApiService.Queries.User.GetUserByMail
{
    public record GetUserByMailQuery(string Email) : IRequest<UserDTO>
    {
    }
}
