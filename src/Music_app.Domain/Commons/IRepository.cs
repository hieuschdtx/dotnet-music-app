namespace Music_app.Domain.Commons;

public interface IRepository<T> where T : Entity
{
    IUnitOfWork UnitOfWork { get; }
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
}