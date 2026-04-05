using Movvi.DLL.Enums;
using MediatR;

namespace Movvi.ApiService.Commands.History.CreateHistory
{
    public record CreateHistoryCommand(int UserId, int PlanId, PurchaseStatus Status) : INotification
    {
    }
}
