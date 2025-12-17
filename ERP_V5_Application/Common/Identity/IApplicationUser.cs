namespace ERP_V5_Application.Common.Identity;

public interface IApplicationUser
{
    Guid Id { get; }
    string Email { get; }
    string FullName { get; }
}
