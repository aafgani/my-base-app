using App.Domain.Event;

namespace App.Domain.Entities;

public abstract class Entity
{
    protected Entity()
    {
    }

    public Guid Id { get; protected set; } = default!;
}
