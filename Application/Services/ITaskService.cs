using System;
using Application.DTOs;
using Application.DTOs.Response;
using Application.DTOs.Task;

namespace Application.Services;

public interface ITaskService
{
    Task<BaseServiceDataResponseModel<Guid>> AddAsync(TaskAddCommandModel taskAddCommandModel);

    Task<BaseServiceDataResponseModel<List<TaskSummaryDto>>> GetAllAsync();
    // Task<List<TaskSummaryDto>> GetAllAsync();

    Task<BaseServiceDataResponseModel<TaskDetailedDto>> GetByIdAsync(Guid id);

    // Task<TaskDetailedDto> GetByIdAsync(Guid id);

    // Task<Guid> AddAsync(TaskAddCommandModel taskAddCommandModel);

    Task<BaseServiceResponseModel> RemoveByIdAsync(Guid id);

    // Task UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel);

    Task<BaseServiceResponseModel> UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel);

    // Task RemoveByIdAsync(Guid id);
}
