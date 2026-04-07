using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        public readonly SqlServerContext _context;
        public readonly IMapper _mapper;
        public GetUserByIdQueryHandler(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.userId, cancellationToken: cancellationToken);
            return _mapper.Map<UserDTO>(user);  
        }
    }
}
