using App.Domain.Entities;
using App.Domain.Interface;

namespace App.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<T?> FirstAsync(ISpecification<T> specification, bool tracking = false);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, bool tracking = false);
}
