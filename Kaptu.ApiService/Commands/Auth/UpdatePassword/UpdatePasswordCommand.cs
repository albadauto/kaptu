using MediatR;

namespace Kaptu.ApiService.Commands.Auth.UpdatePassword
{
    public record UpdatePasswordCommand(string Email, string NewPassword) : IRequest<bool>
    {
    }
}
