using TasksAPI.IAM.Domain.Model.Commands;
using TasksAPI.IAM.Interfaces.REST.Resources;

namespace TasksAPI.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}