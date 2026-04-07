using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.Plans.GetPlanByPriceId
{
    public class GetPlanByPriceIdQueryHandler : IRequestHandler<GetPlanByPriceIdQuery, PlanDTO>
    {
        private readonly SqlServerContext _context;
        private readonly IMapper _mapper;
        public GetPlanByPriceIdQueryHandler(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlanDTO> Handle(GetPlanByPriceIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Plans.FirstOrDefaultAsync(x => x.StripePriceId == request.priceId, cancellationToken: cancellationToken);
            return _mapper.Map<PlanDTO>(result);
        }
    }
}
