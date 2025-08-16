using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Model.Commands;

namespace TasksAPI.Management.Domain.Services;

public interface ITaskkCommandService
{
    Task<Taskk?> handle(CreateTaskkCommand command);
    Task<Taskk?> handle(UpdateTaskkCommand command);
    Task<bool> handle(DeleteTaskkCommand command);
}