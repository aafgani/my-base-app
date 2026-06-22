namespace App.Domain.Seedwork;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(TId id);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task<TEntity?> FirstAsync(ISpecification<TEntity, TId> specification, bool tracking = false);
    Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity, TId> specification, bool tracking = false);
}
