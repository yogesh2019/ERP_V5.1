using ERP_V5_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP_V5_Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Prefer env var if provided; else fallback
        var conn = Environment.GetEnvironmentVariable("ERP_V5__DefaultConnection")
                   ?? "Server=(localdb)\\MSSQLLocalDB;Database=ERP_V5;Integrated Security=True;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(conn)
            .Options;

        return new AppDbContext(options);
    }
}
