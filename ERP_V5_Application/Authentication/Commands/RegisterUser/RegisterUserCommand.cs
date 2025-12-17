using ERP_V5_Application.Authentication.Common;
using MediatR;

namespace ERP_V5_Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<AuthResponse>
{
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
