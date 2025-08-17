using Microsoft.EntityFrameworkCore;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TasksAPI.Database;

public static class DatabaseInitializer
{
    public static IHost InitializeDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            try
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                
                context.Database.EnsureCreated();
                
                var scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "Scripts", "GetTaskksByUser.sql");
                
                if (!File.Exists(scriptPath))
                {
                    var loggger = services.GetRequiredService<ILogger<Program>>();
                    loggger.LogError($"No se encontró el archivo de script: {scriptPath}");
                    return host;
                }
                
                var script = File.ReadAllText(scriptPath);
                context.Database.ExecuteSqlRaw(script);
                
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Procedimiento almacenado creado correctamente");
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Error al inicializar la base de datos");
            }
        }

        return host;
    }
}