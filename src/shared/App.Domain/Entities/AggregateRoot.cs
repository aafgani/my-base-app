using System;
using App.Domain.Event;
using App.Domain.Interface;

namespace App.Domain.Entities;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly List<DomainEvent> _domainEvents = [];
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
