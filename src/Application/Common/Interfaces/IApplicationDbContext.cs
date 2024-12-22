using demo_app.Domain.Entities;

namespace demo_app.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<CalculationItem> CalculationItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
