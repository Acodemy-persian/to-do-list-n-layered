using System;

namespace DataAccess.Repositories;

public interface ITaskRepository
{
    Task<IReadOnlyList<Task>> GetAllAsync();
    Task<Task?> GetByIdAsync(Guid id);
    Task AddAsync(Task task);
    Task UpdateAsync(Task task);
    Task RemoveByIdAsync(Guid id);
}
