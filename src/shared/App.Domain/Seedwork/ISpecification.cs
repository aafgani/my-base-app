using System.Linq.Expressions;

namespace App.Domain.Seedwork;

public interface ISpecification<T, TId> where T : Entity<TId>
{
    Expression<Func<T, bool>> Criteria { get; }

    List<Expression<Func<T, object>>> Includes { get; }
}
