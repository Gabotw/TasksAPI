using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Management.Domain.Model.Commands;
using TasksAPI.Management.Domain.Model.Queries;
using TasksAPI.Management.Domain.Services;
using TasksAPI.Management.Interfaces.REST.Resources;
using TasksAPI.Management.Interfaces.REST.Transform;

namespace TasksAPI.Management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Authorize]
public class TaskkController(ITaskkCommandService taskkCommandService, ITaskkQueryService taskkQueryService)
: ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "ADMIN, EMPLOYEE")]
    public async Task<IActionResult> GetAllTaskks()
    {
        var getAllTaskksQuery = new GetAllTaskksQuery();
        var taskks = await taskkQueryService.handle(getAllTaskksQuery);
        var taskkResources = taskks.Select(TaskkResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(taskkResources);
    }

    [HttpGet("{taskId:int}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetTaskkById(int taskId)
    {
        var getTaskkByIdQuery = new GetTaskkByIdQuery(taskId);
        var taskk = await taskkQueryService.handle(getTaskkByIdQuery);
        if (taskk == null) return NotFound();
        var taskkResource = TaskkResourceFromEntityAssembler.ToResourceFromEntity(taskk);
        return Ok(taskkResource);
    }
    
    [HttpGet("user/{userId:int}")]
    [Authorize(Roles = "ADMIN, EMPLOYEE")]
    public async Task<IActionResult> GetAllTaskksByUserId(int userId)
    {
        if (User.IsInRole("EMPLOYEE"))
        {
            var userIdClaim = User.FindFirst(ClaimTypes.Sid)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int currentUserId) || currentUserId != userId)
            {
                return Forbid(); 
            }
        }

        var getAllTaskksByUserIdQuery = new GetAllTaskksByUserIdQuery(userId);
        var taskks = await taskkQueryService.handle(getAllTaskksByUserIdQuery);
        var taskkResources = taskks.Select(TaskkResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(taskkResources);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateTaskk(CreateTaskkResource resource)
    {
        var createTaskkCommand = CreateTaskkCommandFromResourceAssembler.ToCommandFromResource(resource);
        var taskk = await taskkCommandService.handle(createTaskkCommand);
        if(taskk is null) return BadRequest();
        var taskkResource = TaskkResourceFromEntityAssembler.ToResourceFromEntity(taskk);
        return CreatedAtAction(nameof(GetTaskkById), new {taskId= taskkResource.TaskkId}, taskkResource);
    }

    [HttpPut("{taskId:int}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateTaskk(int taskId, UpdateTaskkResource resource)
    {
        var updateTaskkCommand = UpdateTaskkCommandFromResourceAssembler.ToCommnadFromResource(taskId, resource);
        var taskk = await taskkCommandService.handle(updateTaskkCommand);
        if (taskk is null) return BadRequest();
        var taskkResource = TaskkResourceFromEntityAssembler.ToResourceFromEntity(taskk);
        return Ok(taskkResource);
    }

    [HttpDelete("{taskId:int}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteTaskk(int taskId)
    {
        var deleteTaskkCommand = new DeleteTaskkCommand(taskId);
        var taskk = await taskkCommandService.handle(deleteTaskkCommand);
        if(!taskk) return NotFound();
        return NoContent();
    }
}