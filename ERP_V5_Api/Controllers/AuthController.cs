using ERP_V5_Application.Authentication.Commands.RegisterUser;
using ERP_V5_Application.Authentication.Common;
using ERP_V5_Application.Authentication.Commands.RegisterUser;
using ERP_V5_Application.Authentication.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP_V5_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        AuthResponse response = await _mediator.Send(command);
        return Ok(response);
    }
}
