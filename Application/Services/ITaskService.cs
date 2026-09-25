using System;
using Application.DTOs.Task;

namespace Application.Services;

public interface ITaskService
{
    Task<List<TaskSummaryDto>> GetAllAsync();

    Task<TaskDetailedDto> GetByIdAsync(Guid id);

    Task<Guid> AddAsync(TaskAddCommandModel taskAddCommandModel);

    Task UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel);

    Task RemoveByIdAsync(Guid id);
}
