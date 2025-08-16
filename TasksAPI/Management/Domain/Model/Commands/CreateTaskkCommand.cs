namespace TasksAPI.Management.Domain.Model.Commands;

public record CreateTaskkCommand(string Title, string Description, bool IsCompleted=false, int UserId = 0);