using Microsoft.AspNetCore.Identity;

namespace ERP_V5_Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? FullName { get; set; }
}
