using Microsoft.EntityFrameworkCore;
using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Repositories;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using TasksAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TasksAPI.Management.Infrastructure.EFC.Repositories;

public class TaskkRepository(AppDbContext context) : BaseRepository<Taskk>(context), ITaskkRepository
{
    public Task<Taskk?> FindTaskkByTitleAsync(string title)
    {
        return Context.Set<Taskk>().Where(t => t.Title == title).FirstOrDefaultAsync();
    }
    
    public Task<IEnumerable<Taskk>> FindByUserIdAsync(int userId)
    {
        return Task.FromResult(Context.Set<Taskk>()
            .Where(t => t.UserId == userId)
            .AsEnumerable());
    }
}
