using Movvi.DLL.DTO;
using Movvi.DLL.Models;
using MediatR;

namespace Movvi.ApiService.Commands.Users.AddUser
{
    public record AddUserCommand(string Name, string Password, string Email, string EnterpriseName, int PlanId) : IRequest<bool> 
    {
       
    }
}
