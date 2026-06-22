using System.Linq.Expressions;
using App.Domain.Seedwork;

namespace App.Domain.Specifications;

public abstract class BaseSpecification<T, TId> : ISpecification<T, TId> where T : Entity<TId>
{
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
        Includes = new List<Expression<Func<T, object>>>();
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; }
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}