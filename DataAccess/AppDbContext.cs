using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

/// <summary>
/// Represents the Entity Framework Core database context for the application.
/// </summary>
/// <param name="options">
/// The configuration options used to configure the database context.
/// </param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the collection of work items stored in the database.
    /// </summary>
    public DbSet<WorkItem> WorkItems { get; set; }
}
