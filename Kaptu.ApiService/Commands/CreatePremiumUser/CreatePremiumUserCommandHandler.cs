using Kaptu.ApiService.Commands.History.CreateHistory;
using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.CreatePremiumUser
{
    public class CreatePremiumUserCommandHandler : IRequestHandler<CreatePremiumUserCommand>
    {
        private readonly SqlServerContext _context;
        private readonly IMediator _mediator;
        public CreatePremiumUserCommandHandler(SqlServerContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task Handle(CreatePremiumUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.PremiumUsers.AddAsync(new PremiumUsers
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    PlanId = request.PlanId,
                    NextPayment = DateTime.Now.Date.Add(TimeSpan.FromDays(1)),
                    LastPayment = DateTime.Now.Date,
                    IsActive = request.IsActive
                }, cancellationToken);

                await _context.SaveChangesAsync();
                await _mediator.Publish(new CreateHistoryCommand(request.UserId, request.PlanId, DLL.Enums.PurchaseStatus.Completed), cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }
    }
}
