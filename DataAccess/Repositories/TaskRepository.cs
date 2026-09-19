using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class TaskRepository (AppDbContext appDbContext) : ITaskRepository
{
    public async Task<IReadOnlyList<Task>> GetAllAsync()
    {
        return await appDbContext.Tasks.ToListAsync();
    }
    public async Task<Task?> GetByIdAsync(Guid id)
    {
        return await appDbContext.Tasks.FindAsync(id);
    }

    public async Task AddAsync(Task task)
    {
        await appDbContext.Tasks.AddAsync(task);
        await appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Task task)
    {
        appDbContext.Tasks.Update(task);
        await appDbContext.SaveChangesAsync();
    }

    public async Task RemoveByIdAsync(Guid id)
    {
        var task = await GetByIdAsync(id);
        if (task is not null) appDbContext.Remove(task);
        await appDbContext.SaveChangesAsync();
    }
}
