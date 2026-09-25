using System;
using Application.DTOs;
using Application.DTOs.Response;
using Application.DTOs.Task;
using AutoMapper;
using DataAccess.Repositories;
using Domain.Entities;

namespace Application.Services;

public class TaskService(ITaskRepository taskRepository, IMapper mapper) : ITaskService
{

    // private readonly ITaskRepository taskRepository;
    // public async Task<Guid> AddAsync(TaskAddCommandModel taskAddCommandModel)
    public async Task<BaseServiceDataResponseModel<Guid>> AddAsync(TaskAddCommandModel taskAddCommandModel)
    {
        // throw new NotImplementedException();

        try
        {
            // var taskEntity = new WorkItem();
            var taskEntity = mapper.Map<WorkItem>(taskAddCommandModel);

            // ToDo: Use AutoMapper
            await taskRepository.AddAsync(taskEntity);
            // return taskEntity.Id; 
            return BaseServiceDataResponseModel<Guid>.Success(taskEntity.Id);
        }
        catch (System.Exception)
        {
            return BaseServiceDataResponseModel<Guid>.Failure();
            // throw;
        }
        

    }

    // public Task<List<TaskSummaryDto>> GetAllAsync()
    public async Task<BaseServiceDataResponseModel<List<TaskSummaryDto>>> GetAllAsync()
    {

        try
        {
            var allTasks = await taskRepository.GetAllAsync();
            var taskSummaryDtos = mapper.Map<List<TaskSummaryDto>>(allTasks);
            // all

            return BaseServiceDataResponseModel<List<TaskSummaryDto>>.Success(taskSummaryDtos);
        }
        catch (System.Exception)
        {
            return BaseServiceDataResponseModel<List<TaskSummaryDto>>.Failure();
            // throw;
        }


        // throw new NotImplementedException();
    }

    // public Task<TaskDetailedDto> GetByIdAsync(Guid id)
    public async Task<BaseServiceDataResponseModel<TaskDetailedDto>> GetByIdAsync(Guid id)
    {

        try
        {
            var workItem = await taskRepository.GetByIdAsync(id);
            var taskDetailedDto = mapper.Map<TaskDetailedDto>(workItem);
            return BaseServiceDataResponseModel<TaskDetailedDto>.Success(taskDetailedDto);
        }
        catch (System.Exception)
        {
            return BaseServiceDataResponseModel<TaskDetailedDto>.Failure();
            // throw;
        }


        // throw new NotImplementedException();
    }

    public async Task<BaseServiceResponseModel> RemoveByIdAsync(Guid id)
    {
        try
        {
            await taskRepository.RemoveByIdAsync(id);
            return BaseServiceResponseModel.Success();
        }
        catch (System.Exception)
        {
            return BaseServiceResponseModel.Failure();
            // throw;
        }

        // throw new NotImplementedException();
    }

    // public async Task<BaseServiceResponseModel> UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel)
    // {

    //     try
    //     {
    //         var workItem = await taskRepository.GetByIdAsync(taskUpdateCommandModel.Id);
    //         workItem = mapper.Map<WorkItem>(taskUpdateCommandModel);
    //         await taskRepository.UpdateAsync(workItem);
    //         return BaseServiceResponseModel.Success();
    //     }
    //     catch (System.Exception)
    //     {
    //         return BaseServiceResponseModel.Failure();
    //         // throw;
    //     }

    //     // throw new NotImplementedException();
    // }



    public async Task<BaseServiceResponseModel> UpdateAsync(TaskUpdateCommandModel taskUpdateCommandModel)
    {
        try
        {
            var workItem = await taskRepository.GetByIdAsync(taskUpdateCommandModel.Id);

            if (workItem is null)
                return BaseServiceResponseModel.Failure("Task not found.");

            mapper.Map(taskUpdateCommandModel, workItem);

            await taskRepository.UpdateAsync(workItem);

            return BaseServiceResponseModel.Success();
        }
        catch (Exception)
        {
            return BaseServiceResponseModel.Failure();
        }
    }
}
