using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Interfaces.REST.Resources;

namespace TasksAPI.Management.Interfaces.REST.Transform;

public class TaskkResourceFromEntityAssembler
{
    public static TaskkResource ToResourceFromEntity(Taskk taskk)
    {
        return new TaskkResource(
            taskk.TaskkId,
            taskk.Title,
            taskk.Description,
            taskk.IsCompleted,
            taskk.UserId);
    }
}