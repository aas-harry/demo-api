
using demo_app.Application.Common.Interfaces;

using demo_app.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace demo_app.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>(); // Automatically get DbSet for the entity type
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id); // Find by primary key
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync(); // Get all records from the DbSet
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity); // Add new entity to the DbSet
        await _context.SaveChangesAsync(); // Save changes to the database
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity); // Mark entity as modified
        await _context.SaveChangesAsync(); // Save changes to the database
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id); // Find the entity by ID
        if (entity != null)
        {
            _dbSet.Remove(entity); // Remove entity from the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database
        }
    }
}
