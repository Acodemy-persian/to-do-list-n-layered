using System;
using Application.DTOs.Task;

namespace Application.Services;

public class TaskService : ITaskService
{
    public Task<Guid> AddAsync(TaskAddCommandModel taskAddCommandModel)
    {
        throw new NotImplementedException();

        

    }

    public Task<List<TaskSummaryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TaskDetailedDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel)
    {
        throw new NotImplementedException();
    }
}
