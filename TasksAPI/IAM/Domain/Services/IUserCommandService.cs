using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Domain.Model.Commands;

namespace TasksAPI.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}