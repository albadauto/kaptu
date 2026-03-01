using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.CreatePremiumUser
{
    public class CreatePremiumUserCommandHandler : IRequestHandler<CreatePremiumUserCommand>
    {
        private readonly SqlServerContext _context;
        public CreatePremiumUserCommandHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task Handle(CreatePremiumUserCommand request, CancellationToken cancellationToken)
        {
            await _context.PremiumUsers.AddAsync(new PremiumUsers
            {
                Id = request.Id,
                UserId = request.UserId,
                Plan = request.Plan,
                NextPayment = DateTime.Now.Date.Add(TimeSpan.FromDays(1)),
                LastPayment = DateTime.Now.Date,
                IsActive = request.IsActive
            }, cancellationToken);
        }
    }
}
