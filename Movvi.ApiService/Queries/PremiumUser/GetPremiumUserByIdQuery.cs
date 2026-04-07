using MediatR;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.PremiumUser
{
    public record GetPremiumUserByIdQuery(int userId) : IRequest<PremiumUsersDTO>
    {
    }
}
