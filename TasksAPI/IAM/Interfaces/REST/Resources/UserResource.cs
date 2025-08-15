using TasksAPI.IAM.Domain.Model.ValueObjects;

namespace TasksAPI.IAM.Interfaces.REST.Resources;

public record UserResource(int Id, string Username, Role Role);