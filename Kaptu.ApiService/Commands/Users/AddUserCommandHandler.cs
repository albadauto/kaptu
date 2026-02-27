using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        private SqlServerContext _context;
        public AddUserCommandHandler(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = request.dto;
                await _context.User.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

     
    }
}
