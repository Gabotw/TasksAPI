using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Interfaces.REST.Resources;

namespace TasksAPI.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token, entity.Role);
    }
}