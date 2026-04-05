using Movvi.DLL.DTO;
using MediatR;

namespace Movvi.ApiService.Queries.Parameters.GetParameter
{
    public record GetParameterQuery(string ParameterName) : IRequest<ParameterDTO>
    {
    }
}
