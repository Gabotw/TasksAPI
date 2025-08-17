using TasksAPI.IAM.Application.Internal.OutboundServices;
using TasksAPI.IAM.Domain.Model.Aggregates;
using TasksAPI.IAM.Domain.Model.Commands;
using TasksAPI.IAM.Domain.Model.ValueObjects;
using TasksAPI.IAM.Domain.Repositories;
using TasksAPI.IAM.Domain.Services;
using TasksAPI.Shared.Domain.Repositories;

namespace TasksAPI.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
) : IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");
    
        var hashedPassword = hashingService.HashPassword(command.Password);
  
        if (command.Roles.Length == 0)
            throw new Exception("Al menos un rol debe ser proporcionado");
    
        if (!Enum.TryParse<Role>(command.Roles[0], true, out var userRole))
            throw new Exception($"Rol inválido: {command.Roles[0]}. Los roles válidos son: {string.Join(", ", Enum.GetNames(typeof(Role)))}");
    
        var user = new User(command.Username, hashedPassword).UpdateRole(userRole);
    
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        
        if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
}