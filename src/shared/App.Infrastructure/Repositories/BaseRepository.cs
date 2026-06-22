using App.Domain.Seedwork;

namespace App.Infrastructure.Repositories;

public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> FirstAsync(ISpecification<TEntity, TId> specification, bool tracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity, TId> specification, bool tracking = false)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}