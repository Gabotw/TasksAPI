using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TasksAPI.IAM.Domain.Model.Aggregates;
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

        // builder.Entity<Product>().HasKey(u => u.ProductId);
        // builder.Entity<Product>().Property(u => u.ProductId).IsRequired().ValueGeneratedOnAdd();
        // builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        // builder.Entity<Product>(entity =>
        // {
        //     entity.Property(e => e.Price)
        //         .HasColumnType("decimal(18,2)");
        // });
        // builder.Entity<Product>().Property(u => u.Stock).IsRequired();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}