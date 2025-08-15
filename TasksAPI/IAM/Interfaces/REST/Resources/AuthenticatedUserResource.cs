using TasksAPI.IAM.Domain.Model.ValueObjects;

namespace TasksAPI.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, string Token, Role Role);