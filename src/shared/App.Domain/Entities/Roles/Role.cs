using System;
using App.Domain.Entities.Roles.ValueObjects;
using App.Domain.Seedwork;

namespace App.Domain.Entities.Roles;

public class Role : AggregateRoot<RoleId>
{
    public RoleId Id { get; private set; }
}
