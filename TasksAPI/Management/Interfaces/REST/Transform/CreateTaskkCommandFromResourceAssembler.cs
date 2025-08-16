using TasksAPI.Management.Domain.Model.Commands;
using TasksAPI.Management.Interfaces.REST.Resources;

namespace TasksAPI.Management.Interfaces.REST.Transform;

public class CreateTaskkCommandFromResourceAssembler
{
    public static CreateTaskkCommand ToCommandFromResource(CreateTaskkResource resource)
    {
        return new CreateTaskkCommand(resource.Title, resource.Description, resource.IsCompleted, resource.UserId);
    }
}