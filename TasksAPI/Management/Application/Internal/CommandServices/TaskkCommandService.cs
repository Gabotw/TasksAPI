using TasksAPI.IAM.Domain.Model.Queries;
using TasksAPI.IAM.Domain.Services;
using TasksAPI.Management.Domain.Model.Aggregates;
using TasksAPI.Management.Domain.Model.Commands;
using TasksAPI.Management.Domain.Repositories;
using TasksAPI.IAM.Domain.Model.ValueObjects;
using TasksAPI.Management.Domain.Services;
using TasksAPI.Shared.Domain.Repositories;

namespace TasksAPI.Management.Application.Internal.CommandServices;

public class TaskkCommandService : ITaskkCommandService
{
    private readonly ITaskkRepository _taskkRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserQueryService _userQueryService;

    public TaskkCommandService(ITaskkRepository taskkRepository,
                              IUnitOfWork unitOfWork,
                              IUserQueryService userQueryService)
    {
        _taskkRepository = taskkRepository;
        _unitOfWork = unitOfWork;
        _userQueryService = userQueryService;
    }

    public async Task<Taskk?> handle(CreateTaskkCommand command)
    {
        // Validar que el usuario exista y sea EMPLOYEE
        if (command.UserId != 0)
        {
            var user = await _userQueryService.Handle(new GetUserByIdQuery(command.UserId));
            if (user == null)
                return null; // Usuario no existe

            // Corregir la comparación usando el enum Role
            if (user.Role != Role.EMPLOYEE)
                return null; // Solo empleados pueden ser asignados a tareas
        }

        var taskk = new Taskk(command);
        try
        {
            await _taskkRepository.AddAsync(taskk);
            await _unitOfWork.CompleteAsync();
            return taskk;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the task: {e.Message}");
            return null;
        }
    }

    public async Task<Taskk?> handle(UpdateTaskkCommand command)
    {
        // Validar que el usuario exista y sea EMPLOYEE
        if (command.UserId != 0)
        {
            var user = await _userQueryService.Handle(new GetUserByIdQuery(command.UserId));
            if (user == null)
                return null; // Usuario no existe

            // Corregir la comparación usando el enum Role
            if (user.Role != Role.EMPLOYEE)
                return null; // Solo empleados pueden ser asignados a tareas
        }

        var taskk = await _taskkRepository.FindByIdAsync(command.TaskId);
        if (taskk is null) return null;

        taskk.Update(command.Title, command.Description, command.IsCompleted, command.UserId);
        _taskkRepository.Update(taskk);
        await _unitOfWork.CompleteAsync();
        return taskk;
    }

    public async Task<bool> handle(DeleteTaskkCommand command)
    {
        var taskk = await _taskkRepository.FindByIdAsync(command.TaskId);
        if(taskk is null) return false;
        _taskkRepository.Remove(taskk);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}