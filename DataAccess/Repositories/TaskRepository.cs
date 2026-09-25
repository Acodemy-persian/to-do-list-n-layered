using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

/// <summary>
/// Provides data access operations for <see cref="WorkItem"/> entities.
/// </summary>
/// <param name="appDbContext">
/// The database context used to access and persist work items.
/// </param>
public class TaskRepository(AppDbContext appDbContext) : ITaskRepository
{

    /// <summary>
    /// Retrieves all work items from the database.
    /// </summary>
    /// <returns>
    /// A read-only list containing all work items.
    /// </returns>
    public async Task<IReadOnlyList<WorkItem>> GetAllAsync()
    {
    return await appDbContext.WorkItems.ToListAsync();
    }
    
    /// <summary>
    /// Retrieves a work item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the work item.</param>
    /// <returns>
    /// The matching work item, or <c>null</c> if no work item is found.
    /// </returns>
    public async Task<WorkItem?> GetByIdAsync(Guid id)
    {
        return await appDbContext.WorkItems.FindAsync(id);
    }
    
    /// <summary>
    /// Adds a new work item to the database.
    /// </summary>
    /// <param name="task">The work item to add.</param>
    public async Task AddAsync(WorkItem task)
    {
        await appDbContext.WorkItems.AddAsync(task);
        await appDbContext.SaveChangesAsync();
    }
    
    /// <summary>
    /// Updates an existing work item in the database.
    /// </summary>
    /// <param name="task">The work item to update.</param>
    public async Task UpdateAsync(WorkItem task)
    {
        appDbContext.WorkItems.Update(task);
        await appDbContext.SaveChangesAsync();
    }
    
    /// <summary>
    /// Removes a work item from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the work item to remove.</param>
    public async Task RemoveByIdAsync(Guid id)
    {
        var task = await GetByIdAsync(id);
        if (task is null) return;
        appDbContext.Remove(task);
        await appDbContext.SaveChangesAsync();
    }
}
