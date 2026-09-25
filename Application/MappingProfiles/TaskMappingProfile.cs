using System;
using Application.DTOs.Task;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<TaskAddCommandModel, WorkItem>();
        CreateMap<TaskUpdateCommandModel, WorkItem>();

        CreateMap<WorkItem, TaskSummaryDto>();
        CreateMap<WorkItem, TaskDetailedDto>();
    }
}
