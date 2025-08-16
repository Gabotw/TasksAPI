using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

public static class DatabaseInitializer
{
    public static IHost InitializeDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            
            var scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "Scripts", "GetTaskksByUser.sql");
            var script = File.ReadAllText(scriptPath);
            
            context.Database.ExecuteSqlRaw(script);
        }
        
        return host;
    }
}