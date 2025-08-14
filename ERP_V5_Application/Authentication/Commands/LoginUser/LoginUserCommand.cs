using ERP_V5_Application.Authentication.Common;
using MediatR;

namespace ERP_V5_Application.Authentication.Commands.LoginUser;

public class LoginUserCommand : IRequest<AuthResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
