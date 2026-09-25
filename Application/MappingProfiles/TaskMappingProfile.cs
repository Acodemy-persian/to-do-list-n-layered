using Application.DTOs.Task;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles;

/// <summary>
/// Defines AutoMapper mappings between task DTOs and the <see cref="WorkItem"/> entity.
/// </summary>
public class TaskMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskMappingProfile"/> class
    /// and configures task-related mappings.
    /// </summary>
    public TaskMappingProfile()
    {
        CreateMap<TaskAddCommandModel, WorkItem>();
        CreateMap<TaskUpdateCommandModel, WorkItem>();

        CreateMap<WorkItem, TaskSummaryDto>();
        CreateMap<WorkItem, TaskDetailedDto>();
    }
}
