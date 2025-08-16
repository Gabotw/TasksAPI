using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Model.Queries;
using TasksAPI.Management.Domain.Repositories;
using TasksAPI.Management.Domain.Services;

namespace TasksAPI.Management.Application.Internal.QueryServices;

public class TaskkQueryService(ITaskkRepository taskkRepository): ITaskkQueryService
{
    public async Task<Taskk?> handle(GetTaskkByIdQuery query)
    {
        return await taskkRepository.FindByIdAsync(query.TaskId);
    }

    public async Task<IEnumerable<Taskk>> handle(GetAllTaskksQuery query)
    {
        return await taskkRepository.ListAsync();
    }

    public async Task<IEnumerable<Taskk>> handle(GetAllTaskksByUserIdQuery query)
    {
        return await taskkRepository.FindByUserIdAsync(query.UserId);
    }
}