namespace TasksAPI.Management.Interfaces.REST.Resources;

public record UpdateTaskkResource(string Title, string Description, bool IsCompleted, int UserId);