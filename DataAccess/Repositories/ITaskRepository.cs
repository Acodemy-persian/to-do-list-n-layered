using Domain.Entities;

namespace DataAccess.Repositories;

public interface ITaskRepository
{
    Task<IReadOnlyList<WorkItem>> GetAllAsync();
    Task<WorkItem?> GetByIdAsync(Guid id);
    Task AddAsync(WorkItem task);
    Task UpdateAsync(WorkItem task);
    Task RemoveByIdAsync(Guid id);
}
