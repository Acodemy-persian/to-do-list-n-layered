using Application.DTOs.Task;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace Presentation.Controllers;

/// <summary>
/// Provides API endpoints for creating, retrieving, updating, and removing tasks.
/// </summary>
/// <param name="taskService">The service responsible for task-related operations.</param>
[ApiController]
[Route("api/[controller]")]
[HandleServiceResult]
public class TaskController(ITaskService taskService) : ControllerBase
{
    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="taskAddCommandModel">The data required to create the task.</param>
    /// <returns>
    /// An HTTP 201 Created response containing the service result
    /// and a reference to the newly created task.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Add(TaskAddCommandModel taskAddCommandModel)
    {
    var result = await taskService.AddAsync(taskAddCommandModel);
    return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }
    
    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    /// <returns>
    /// An HTTP 200 OK response containing the service result and the list of tasks.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await taskService.GetAllAsync();
        return Ok(result);
    }
    
    /// <summary>
    /// Retrieves a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task.</param>
    /// <returns>
    /// An HTTP 200 OK response containing the service result and the requested task.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await taskService.GetByIdAsync(id);
        return Ok(result);
    }
    
    /// <summary>
    /// Removes a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task to remove.</param>
    /// <returns>
    /// An HTTP 200 OK response containing the service result of the removal operation.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveById(Guid id)
    {
        var result = await taskService.RemoveByIdAsync(id);
        return Ok(result);
    }
    
    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <param name="taskUpdateCommandModel">The data required to update the task.</param>
    /// <returns>
    /// An HTTP 200 OK response containing the service result of the update operation.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(TaskUpdateCommandModel taskUpdateCommandModel)
    {
        var result = await taskService.UpdateAsync(taskUpdateCommandModel);
        return Ok(result);
    }
}
