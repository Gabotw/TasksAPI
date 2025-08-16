namespace TasksAPI.Management.Interfaces.REST.Resources;

public record TaskkResource(int TaskkId, string Title, string Description, bool IsCompleted, int UserId);