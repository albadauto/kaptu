using MediatR;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.Plans.GetPlans
{
    public record GetPlansQuery(int idPlan) : IRequest<PlanDTO>
    {
    }
}
