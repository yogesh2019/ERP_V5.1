using ERP_V5_Application.Authentication.Commands.RegisterUser;
using ERP_V5_Application.Authentication.Common;
using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Authentication.Commands.RegisterUser;
using ERP_V5_Application.Authentication.Common;
using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ERP_V5_Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = request.FullName  // ✅ this was not possible with IdentityUser<Guid>
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }

        // Ensure role exists
        const string defaultRole = "User";
        if (!await _roleManager.RoleExistsAsync(defaultRole))
        {
            var role = new ApplicationRole { Name = defaultRole };
            await _roleManager.CreateAsync(role);
        }

        // Assign role
        await _userManager.AddToRoleAsync(user, defaultRole);

        // Get roles to include in JWT claims
        var roles = await _userManager.GetRolesAsync(user);

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email!, roles);

        return new AuthResponse
        {
            UserId = user.Id,
            Email = user.Email!,
            Token = token
        };
    }
}
