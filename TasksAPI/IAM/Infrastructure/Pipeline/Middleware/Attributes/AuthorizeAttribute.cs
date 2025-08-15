using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Domain.Model.ValueObjects;

namespace TasksAPI.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly Role[] _roles;

    public AuthorizeAttribute(params Role[] roles)
    {
        _roles = roles;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping Authorization");
            return;
        }
        // If user is logged in, this will be set
        var user = (User?)context.HttpContext.Items["User"];

        if (user == null) context.Result = new UnauthorizedResult();
        
        
        if (_roles.Length == 0)
            return;

        if (!_roles.Contains(user.Role))
            context.Result = new ForbidResult();
    }
}