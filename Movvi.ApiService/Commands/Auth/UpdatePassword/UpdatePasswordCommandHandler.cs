using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Movvi.ApiService.Commands.Auth.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        public SqlServerContext _context;
        public UpdatePasswordCommandHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            user!.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            _context.User.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
