namespace Application.DTOs.Task;

public class TaskSummaryDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the work item.
    /// </summary>
    public Guid Id {get; set;}

    /// <summary>
    /// Gets or sets the title of the work item.
    /// </summary>
    public string Title {get; set;} = null!;
}
