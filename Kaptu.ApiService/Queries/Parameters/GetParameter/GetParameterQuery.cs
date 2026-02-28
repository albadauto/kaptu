using Kaptu.DLL.DTO;
using MediatR;

namespace Kaptu.ApiService.Queries.Parameters.GetParameter
{
    public record GetParameterQuery(string ParameterName) : IRequest<ParameterDTO>
    {
    }
}
