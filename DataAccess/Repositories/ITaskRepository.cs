using Domain.Entities;

namespace DataAccess.Repositories;

/// <summary>
/// Defines data access operations for <see cref="WorkItem"/> entities.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Retrieves all work items from the database.
    /// </summary>
    /// <returns>
    /// A read-only list containing all work items.
    /// </returns>
    Task<IReadOnlyList<WorkItem>> GetAllAsync();

    /// <summary>
    /// Retrieves a work item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the work item.</param>
    /// <returns>
    /// The matching work item, or <c>null</c> if no work item is found.
    /// </returns>
    Task<WorkItem?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new work item to the database.
    /// </summary>
    /// <param name="task">The work item to add.</param>
    Task AddAsync(WorkItem task);

    /// <summary>
    /// Updates an existing work item in the database.
    /// </summary>
    /// <param name="task">The work item to update.</param>
    Task UpdateAsync(WorkItem task);

    /// <summary>
    /// Removes a work item from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the work item to remove.</param>
    Task RemoveByIdAsync(Guid id);
}
