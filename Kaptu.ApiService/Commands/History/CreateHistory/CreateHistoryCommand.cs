using Kaptu.DLL.Enums;
using MediatR;

namespace Kaptu.ApiService.Commands.History.CreateHistory
{
    public record CreateHistoryCommand(int UserId, int PlanId, PurchaseStatus Status) : INotification
    {
    }
}
