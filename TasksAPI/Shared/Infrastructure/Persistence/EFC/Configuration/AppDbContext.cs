using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration
        
        // IAM Context

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.Role).HasConversion<string>();

         builder.Entity<Taskk>().HasKey(u => u.TaskkId);
         builder.Entity<Taskk>().Property(u => u.TaskkId).IsRequired().ValueGeneratedOnAdd();
         builder.Entity<Taskk>().Property(p => p.Title).IsRequired().HasMaxLength(100);
         builder.Entity<Taskk>().Property(u => u.Description).IsRequired();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}