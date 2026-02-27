using Kaptu.DLL.DTO;
using Kaptu.DLL.Models;
using MediatR;

namespace Kaptu.ApiService.Commands.Users.AddUser
{
    public record AddUserCommand(string Name, string Password, string Email, string EnterpriseName, int Plan) : IRequest<bool> 
    {
       
    }
}
