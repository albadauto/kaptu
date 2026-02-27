using AutoMapper;
using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.Users.AddUser
{
    public class AddUserCommandHandler(SqlServerContext context, IMapper mapper) : IRequestHandler<AddUserCommand, bool>
    {
        private SqlServerContext _context = context;
        private IMapper _mapper = mapper;

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
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
