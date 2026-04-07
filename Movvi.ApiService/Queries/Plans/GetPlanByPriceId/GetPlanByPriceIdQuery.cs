using MediatR;
using Movvi.DLL.DTO;

namespace Movvi.ApiService.Queries.Plans.GetPlanByPriceId
{
    public record GetPlanByPriceIdQuery(string priceId) : IRequest<PlanDTO>
    {
    }
}
