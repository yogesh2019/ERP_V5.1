namespace ERP_V5_Application.Authentication.Common;

public class AuthResponse
{
    public Guid UserId { get; init; }
    public string Email { get; init; } = null!;
    public string Token { get; init; } = null!;
}
