using Microsoft.Data.SqlClient;
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
    
    public Task<IEnumerable<Taskk>> FindByUserIdAndIsNotDeletedAsync(int userId)
    {
        return Task.FromResult(Context.Set<Taskk>()
            .Where(t => t.UserId == userId && !t.IsDeleted)
            .AsEnumerable());
    }

    public async Task<IEnumerable<Taskk>> FindByUserIdWithStoredProcedureAsync(int userId)
    {
        var parameter = new SqlParameter("UserId", userId);
        return await Context.Set<Taskk>()
            .FromSqlRaw("EXEC GetTasksByUser @UserId = {0}", parameter)
            .ToListAsync();
    }

    public Task<IEnumerable<Taskk>> FindAllTaskksIsNotDeletedAsync()
    {
        return Task.FromResult(Context.Set<Taskk>()
            .Where(t => !t.IsDeleted)
            .AsEnumerable());
    }
}
