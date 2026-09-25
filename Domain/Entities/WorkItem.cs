using System;

namespace Domain.Entities;

public class WorkItem
{
    public Guid Id {get; set;}
    public string Title {get; set;} = null!;
    public string? Description {get; set;} = null;
    public bool IsCompleted {get; set;}
    public DateTime DueDate {get; set;}


}
