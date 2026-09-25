namespace Application.DTOs.Task;

public class TaskAddCommandModel
{
    /// <summary>
    /// Gets or sets the title of the work item.
    /// </summary>
    public string Title {get; set;} = null!;

    /// <summary>
    /// Gets or sets an optional description providing additional details about the work item.
    /// </summary>
    public string? Description {get; set;} = null;

    /// <summary>
    /// Gets or sets a value indicating whether the work item has been completed.
    /// </summary>
    public bool IsCompleted {get; set;}

    /// <summary>
    /// Gets or sets the date and time by which the work item should be completed.
    /// </summary>
    public DateTime DueDate {get; set;}
}
