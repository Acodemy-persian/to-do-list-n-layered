using Application.DTOs.Response;
using Application.DTOs.Task;

namespace Application.Services;

/// <summary>
/// Defines application service operations for managing tasks.
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="taskAddCommandModel">
    /// The data required to create the task.
    /// </param>
    /// <returns>
    /// A service response containing the unique identifier of the newly created task.
    /// </returns>
    Task<BaseServiceDataResponseModel<Guid>> AddAsync(TaskAddCommandModel taskAddCommandModel);

    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    /// <returns>
    /// A service response containing a list of task summary DTOs.
    /// </returns>
    Task<BaseServiceDataResponseModel<List<TaskSummaryDto>>> GetAllAsync();

    /// <summary>
    /// Retrieves a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task.</param>
    /// <returns>
    /// A service response containing the detailed task information.
    /// </returns>
    Task<BaseServiceDataResponseModel<TaskDetailedDto>> GetByIdAsync(Guid id);

    /// <summary>
    /// Removes a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task to remove.</param>
    /// <returns>
    /// A service response indicating whether the removal operation was successful.
    /// </returns>
    Task<BaseServiceResponseModel> RemoveByIdAsync(Guid id);

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <param name="taskUpdateCommandModel">
    /// The data required to update the task.
    /// </param>
    /// <returns>
    /// A service response indicating whether the update operation was successful.
    /// </returns>
    Task<BaseServiceResponseModel> UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel);
}
