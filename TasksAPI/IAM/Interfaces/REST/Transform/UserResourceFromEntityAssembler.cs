using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Interfaces.REST.Resources;

namespace TasksAPI.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username, entity.Role);
    }
}