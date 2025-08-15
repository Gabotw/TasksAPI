using TasksAPI.Shared.Domain.Repositories;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TasksAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}