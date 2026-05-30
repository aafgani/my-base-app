using App.Domain.Specifications;

namespace App.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task<TEntity?> FirstAsync(ISpecification<TEntity> specification, bool tracking = false);
    Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification, bool tracking = false);
}
