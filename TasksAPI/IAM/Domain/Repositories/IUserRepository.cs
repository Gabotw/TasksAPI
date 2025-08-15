using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.Shared.Domain.Repositories;

namespace TasksAPI.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}