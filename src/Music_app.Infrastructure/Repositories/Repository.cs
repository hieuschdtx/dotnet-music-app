using Microsoft.EntityFrameworkCore;
using Music_app.Domain.Commons;
using Music_app.Infrastructure.Data;

namespace Music_app.Infrastructure;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly MusicDbContext _context;

    public Repository(MusicDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<T> AddAsync(T entity)
    {
        return (await _context.Set<T>().AddAsync(entity)).Entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return (await _context.Set<T>().FirstOrDefaultAsync(x => x.id == id))!;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await Task.CompletedTask;
    }
}