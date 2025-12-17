using Microsoft.AspNetCore.Identity;
using ERP_V5_Application.Common.Identity;

namespace ERP_V5_Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>, IApplicationUser
{
    public string? FullName { get; set; }
}
