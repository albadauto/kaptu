using AutoMapper;
using Movvi.ApiService.Commands.History.CreateHistory;
using Movvi.DLL.Models;
using MediatR;

namespace Movvi.ApiService.Commands.Users.AddUser
{
    public class AddUserCommandHandler(SqlServerContext context, IMapper mapper, IMediator mediator) : IRequestHandler<AddUserCommand, bool>
    {
        private SqlServerContext _context = context;
        private IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                await _context.User.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new CreateHistoryCommand ( user.Id, request.PlanId, DLL.Enums.PurchaseStatus.Pending), cancellationToken);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

     
    }
}
