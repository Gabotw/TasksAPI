namespace TasksAPI.Management.Domain.Model.Commands;

public record UpdateTaskkCommand(int TaskId, string Title, string Description, bool IsCompleted, int UserId);