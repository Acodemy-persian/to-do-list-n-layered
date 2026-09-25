using System;
using Application.DTOs;
using Application.DTOs.Task;

namespace Application.Services;

public interface ITaskService
{
    Task<BaseServiceDataResponseModel<Guid>> AddAsync(TaskAddCommandModel taskAddCommandModel);

    Task<BaseServiceDataResponseModel<List<TaskSummaryDto>>> GetAllAsync();
    // Task<List<TaskSummaryDto>> GetAllAsync();

    Task<TaskDetailedDto> GetByIdAsync(Guid id);

    // Task<Guid> AddAsync(TaskAddCommandModel taskAddCommandModel);

    Task UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel);

    Task RemoveByIdAsync(Guid id);
}
