using AutoMapper;
using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.Tenants.CreateTenant
{
    public class CreateTenantCommandHandler(SqlServerContext context, IMapper mapper) : IRequestHandler<CreateTenantCommand, bool>
    {
        private readonly SqlServerContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = _mapper.Map<Tenant>(request);
            await _context.Tenant.AddAsync(tenant, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
