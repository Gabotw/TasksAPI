namespace TasksAPI.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, string[] Roles);