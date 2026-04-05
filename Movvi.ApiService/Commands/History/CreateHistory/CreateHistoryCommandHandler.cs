using MediatR;

namespace Movvi.ApiService.Commands.History.CreateHistory
{
    public class CreateHistoryCommandHandler : INotificationHandler<CreateHistoryCommand>
    {
        private readonly SqlServerContext _context;
        public CreateHistoryCommandHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateHistoryCommand request, CancellationToken cancellationToken)
        {
            await _context.PurchaseHistory.AddAsync(new DLL.Models.PurchaseHistory
            {
                UserId = request.UserId,
                Status = (int)request.Status,
                PlanId = request.PlanId
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

        }

        
    }
}
