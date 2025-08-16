using System.ComponentModel.DataAnnotations;
using TasksAPI.Management.Domain.Model.Commands;

namespace TasksAPI.Management.Domain.Model.Aggregates;

public partial class Taskk
{
    public int TaskkId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    
    [StringLength(500)]
    public string Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    [Range(0, int.MaxValue)]
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