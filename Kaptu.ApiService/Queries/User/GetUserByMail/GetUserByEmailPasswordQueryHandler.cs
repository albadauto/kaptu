using Kaptu.DLL.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService.Queries.User.GetUserByMail
{
    public class GetUserByEmailPasswordQueryHandler : IRequestHandler<GetUserByEmailPasswordQuery, UserDTO>
    {
        private readonly SqlServerContext _context;
        public GetUserByEmailPasswordQueryHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> Handle(GetUserByEmailPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == request.Email,
                cancellationToken: cancellationToken) ?? new();
        }
    
    }
}
