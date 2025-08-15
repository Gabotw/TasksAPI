using TasksAPI.IAM.Domain.Model.Aggregates;

namespace TasksAPI.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}