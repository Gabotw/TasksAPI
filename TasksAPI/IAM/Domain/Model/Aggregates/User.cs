using System.Text.Json.Serialization;
using TasksAPI.IAM.Domain.Model.ValueObjects;

namespace TasksAPI.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty) { }
    
    public int Id { get;  }

    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public Role Role { get; private set; } = Role.EMPLOYEE;
    
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateRole(Role role)
    {
        Role = role;
        return this;
    }
}