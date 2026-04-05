using MediatR;

namespace Movvi.ApiService.Commands.Tenants.CreateTenant
{
    public record CreateTenantCommand(string Name, string Plan, DateTime? TrialsEnd, bool IsActive, int userid) : IRequest<bool>
    {
    }
}
