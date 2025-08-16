namespace TasksAPI.Management.Interfaces.REST.Resources;

public record CreateTaskkResource(string Title,string Description, bool IsCompleted=false, int UserId = 0);