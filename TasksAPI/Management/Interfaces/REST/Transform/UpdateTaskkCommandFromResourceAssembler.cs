using TasksAPI.Management.Domain.Model.Commands;
using TasksAPI.Management.Interfaces.REST.Resources;

namespace TasksAPI.Management.Interfaces.REST.Transform;

public class UpdateTaskkCommandFromResourceAssembler
{
    public static UpdateTaskkCommand ToCommnadFromResource(int taskkId, UpdateTaskkResource resource)
    {
        return new UpdateTaskkCommand(
            taskkId,
            resource.Title,
            resource.Description,
            resource.IsCompleted,
            resource.UserId);
    }
}