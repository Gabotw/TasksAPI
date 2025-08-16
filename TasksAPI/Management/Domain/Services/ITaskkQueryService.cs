using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Model.Queries;

namespace TasksAPI.Management.Domain.Services;

public interface ITaskkQueryService
{
    Task<Taskk?> handle(GetTaskkByIdQuery query);
    Task<IEnumerable<Taskk>> handle(GetAllTaskksQuery query);
    
    Task<IEnumerable<Taskk>> handle(GetAllTaskksByUserIdQuery query);
}