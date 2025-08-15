using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Domain.Model.Queries;

namespace TasksAPI.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}