using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Shared.Domain.Repositories;

namespace TasksAPI.Management.Domain.Repositories;

public interface ITaskkRepository: IBaseRepository<Taskk>
{
    Task<Taskk?> FindTaskkByTitleAsync(string title);
    Task<IEnumerable<Taskk>> FindByUserIdAndIsNotDeletedAsync(int userId);
    Task<IEnumerable<Taskk>> FindByUserIdWithStoredProcedureAsync(int userId);
    
    Task<IEnumerable<Taskk>> FindAllTaskksIsNotDeletedAsync();
}