using TasksAPI.Management.Domain.Model.Commands;

namespace TasksAPI.Management.Domain.Model.Aggregates;

public partial class Taskk
{
    public int TaskkId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public int UserId { get; set; }

    public Taskk(string title, string description, bool isCompleted = false, int userId = 0)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        UserId = userId;
    }
    public Taskk(CreateTaskkCommand command)
    {
        Title = command.Title;
        Description = command.Description;
        IsCompleted = command.IsCompleted;
        UserId = command.UserId;
    }

    public void Update(string title, string description, bool isCompleted, int userId = 0)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        UserId = userId;
    }
}