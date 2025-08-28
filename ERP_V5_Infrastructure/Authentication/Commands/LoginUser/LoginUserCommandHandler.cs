using ERP_V5_Application.Authentication.Commands.LoginUser;
using ERP_V5_Application.Authentication.Common;
using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ERP_V5_Infrastructure.Authentication.Commands.LoginUser;
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("Invalid Credentials");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
        {
            throw new Exception("Invalid Credentials");
        }
        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, roles);
        return new AuthResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Token = token,
        };
    }
}
