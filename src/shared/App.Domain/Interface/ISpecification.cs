using System.Linq.Expressions;
using App.Domain.Entities;

namespace App.Domain.Interface;

public interface ISpecification<T> where T : Entity
{
    Expression<Func<T, bool>> Criteria { get; }

    List<Expression<Func<T, object>>> Includes { get; }
}
