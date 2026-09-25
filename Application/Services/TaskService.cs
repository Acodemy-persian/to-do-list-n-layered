using Application.DTOs.Response;
using Application.DTOs.Task;
using AutoMapper;
using DataAccess.Repositories;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Provides application services for creating, retrieving, updating, and removing tasks.
/// </summary>
/// <param name="taskRepository">
/// The repository responsible for data access operations related to tasks.
/// </param>
/// <param name="mapper">
/// The AutoMapper instance used to map between entities and DTOs.
/// </param>
public class TaskService(ITaskRepository taskRepository, IMapper mapper) : ITaskService
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
    public async Task<BaseServiceDataResponseModel<Guid>> AddAsync(
    TaskAddCommandModel taskAddCommandModel)
    {
        try
        {
            var taskEntity = mapper.Map<WorkItem>(taskAddCommandModel);
            await taskRepository.AddAsync(taskEntity);

            return BaseServiceDataResponseModel<Guid>.Success(taskEntity.Id);
        }
        catch (Exception)
        {
            // ToDo: Add GlobalException handler and Use ILogger
            return BaseServiceDataResponseModel<Guid>.Failure();
        }
    }

    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    /// <returns>
    /// A service response containing a list of task summary DTOs.
    /// </returns>
    public async Task<BaseServiceDataResponseModel<List<TaskSummaryDto>>> GetAllAsync()
    {
        try
        {
            var allTasks = await taskRepository.GetAllAsync();
            var taskSummaryDtos = mapper.Map<List<TaskSummaryDto>>(allTasks);

            return BaseServiceDataResponseModel<List<TaskSummaryDto>>.Success(taskSummaryDtos);
        }
        catch (Exception)
        {
            // ToDo: Add GlobalException handler and Use ILogger
            return BaseServiceDataResponseModel<List<TaskSummaryDto>>.Failure();
        }
    }

    /// <summary>
    /// Retrieves a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task.</param>
    /// <returns>
    /// A service response containing the detailed task information.
    /// </returns>
    public async Task<BaseServiceDataResponseModel<TaskDetailedDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var workItem = await taskRepository.GetByIdAsync(id);
            var taskDetailedDto = mapper.Map<TaskDetailedDto>(workItem);

            return BaseServiceDataResponseModel<TaskDetailedDto>.Success(taskDetailedDto);
        }
        catch (Exception)
        {
            // ToDo: Add GlobalException handler and Use ILogger
            return BaseServiceDataResponseModel<TaskDetailedDto>.Failure();
        }
    }

    /// <summary>
    /// Removes a task by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the task to remove.</param>
    /// <returns>
    /// A service response indicating whether the removal operation was successful.
    /// </returns>
    public async Task<BaseServiceResponseModel> RemoveByIdAsync(Guid id)
    {
        try
        {
            await taskRepository.RemoveByIdAsync(id);

            return BaseServiceResponseModel.Success();
        }
        catch (Exception)
        {
            // ToDo: Add GlobalException handler and Use ILogger
            return BaseServiceResponseModel.Failure();
        }
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <param name="taskUpdateCommandModel">
    /// The data required to update the task.
    /// </param>
    /// <returns>
    /// A service response indicating whether the update operation was successful.
    /// </returns>
    public async Task<BaseServiceResponseModel> UpdateAsync(
        TaskUpdateCommandModel taskUpdateCommandModel)
    {
        try
        {
            var workItem = await taskRepository.GetByIdAsync(taskUpdateCommandModel.Id);

            if (workItem is null)
            {
                return BaseServiceResponseModel.Failure("Task not found.");
            }

            mapper.Map(taskUpdateCommandModel, workItem);
            await taskRepository.UpdateAsync(workItem);

            return BaseServiceResponseModel.Success();
        }
        catch (Exception)
        {
            // ToDo: Add GlobalException handler and Use ILogger
            return BaseServiceResponseModel.Failure();
        }
    }
}
