using App.Domain.Entities;
using App.Domain.Interface;
using App.Domain.Repositories;
using App.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> FirstAsync(ISpecification<TEntity> specification, bool tracking = false)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        query = query.Where(specification.Criteria);

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification, bool tracking = false)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        query = query.Where(specification.Criteria);

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();

        // return await query
        //     .AsNoTracking()
        //     // .Select(x => x.MapToDomain())
        //     .ToListAsync();
    }

    public Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }
}