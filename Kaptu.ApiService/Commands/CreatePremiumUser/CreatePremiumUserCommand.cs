using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.CreatePremiumUser
{
    public record CreatePremiumUserCommand(int Id, int UserId, int PlanId ,
        DateTime NextPayment,DateTime LastPayment,bool IsActive ) : IRequest{
    }
}
