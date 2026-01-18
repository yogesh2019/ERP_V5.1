using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP_V5_Infrastructure.Persistance;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Prefer env var if provided; else fallback
        var conn = Environment.GetEnvironmentVariable("ERP_V5__DefaultConnection")
                   ?? "Server=DESKTOP-UVSKIA8\\SQLEXPRESS03;Database=ERP_V5;Trusted_Connection=True;MultipleActiveResultSets=true";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(conn)
            .Options;

        return new AppDbContext(options);
    }
}
