using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Management.Interfaces.REST.Resources;

public record UpdateTaskkResource(
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 100 caracteres")]
    string Title,
    
    [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
    string Description,
    
    bool IsCompleted,
    
    [Range(0, int.MaxValue, ErrorMessage = "El ID del usuario debe ser un valor positivo o cero")]
    int UserId);