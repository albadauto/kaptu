using Movvi.DLL.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Movvi.ApiService.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserDTO>>
    {
        public readonly SqlServerContext _context; 
        public GetUserQueryHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<List<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.User.Select(x => (UserDTO)x).ToListAsync(cancellationToken: cancellationToken);
            return result;
        }
    }
}
