using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.PremiumUser
{
    public class GetPremiumUserByIdQueryHandler : IRequestHandler<GetPremiumUserByIdQuery, PremiumUsersDTO>
    {
        private readonly SqlServerContext _context;
        private readonly IMapper _mapper;
        public GetPremiumUserByIdQueryHandler(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PremiumUsersDTO> Handle(GetPremiumUserByIdQuery request, CancellationToken cancellationToken)
        {
            var premiumUser = await _context.PremiumUsers
                .FirstOrDefaultAsync(x => x.UserId == request.userId, cancellationToken: cancellationToken);
            return _mapper.Map<PremiumUsersDTO>(premiumUser);
        }
    }
}
