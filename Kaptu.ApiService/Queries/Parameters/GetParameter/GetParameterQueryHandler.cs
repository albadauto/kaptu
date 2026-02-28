using Kaptu.DLL.DTO;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService.Queries.Parameters.GetParameter
{
    public class GetParameterQueryHandler : IRequestHandler<GetParameterQuery, ParameterDTO>
    {
        public SqlServerContext _context;
        public GetParameterQueryHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<ParameterDTO> Handle(GetParameterQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Database
                        .SqlQueryRaw<ParameterDTO>(@"
                            SELECT ID, PARAMETER, [VALUE]
                            FROM PARAMETERS WITH(NOLOCK)
                            WHERE PARAMETER = @param
                        ",
                        new SqlParameter("@param", request.ParameterName))
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return result ?? new();
        }
    }
}
