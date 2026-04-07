using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.Plans.GetPlans
{
    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, PlanDTO>
    {
        public SqlServerContext _context;
        private readonly IMapper _mapper;
        public GetPlansQueryHandler(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlanDTO> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Plans.FirstOrDefaultAsync(x => x.Id == request.idPlan, cancellationToken: cancellationToken);
            return _mapper.Map<PlanDTO>(result);
        }
    }
}
