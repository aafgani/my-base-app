using System;
using App.Domain.Entities.Roles.ValueObjects;

namespace App.Domain.Entities.Users;

public class UserRole
{
    public RoleId RoleId { get; private set; }
    public DateTime AssignedAt { get; private set; }

    public static UserRole Create(RoleId roleId)
    {
        return new UserRole(roleId);
    }

    private UserRole(RoleId roleId)
    {
        RoleId = roleId;
        AssignedAt = DateTime.UtcNow;
    }
}
