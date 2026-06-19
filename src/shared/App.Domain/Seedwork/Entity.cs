using App.Domain.Event;

namespace App.Domain.Seedwork;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;
}
