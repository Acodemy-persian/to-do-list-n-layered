using System;

namespace Application.DTOs.Task;

public class TaskSummaryDto
{
    public Guid Id {get; set;}
    public string Title {get; set;} = null!;
    // public string? Description {get; set;} = null;
    // public bool IsCompleted {get; set;}
    // public DateTime DueDate {get; set;}
}
