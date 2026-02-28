using Kaptu.DLL.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kaptu.ApiService.Queries.User.GetUserByMail
{
    public class GetUserByMailQueryHandler(SqlServerContext SqlServerContext) : IRequestHandler<GetUserByMailQuery, UserDTO>
    {
        private readonly SqlServerContext _sqlServerContext = SqlServerContext;

        public async Task<UserDTO> Handle(GetUserByMailQuery request, CancellationToken cancellationToken)
        {
            return await _sqlServerContext.User.Where(u => u.Email == request.Email).Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password,
                Email = u.Email,
                Plan = u.Plan,
                EnterpriseName = u.EnterpriseName
            }).FirstOrDefaultAsync(cancellationToken) ?? new();
        }
    }
}
