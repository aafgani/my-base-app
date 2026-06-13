using System;
using App.Domain.Entities;
using App.Infrastructure.Persistence.Records;

namespace App.Infrastructure.Mapping;

public static class UserMappings
{
    public static Domain.Entities.User MapToDomain(this Persistence.Records.User record)
    {
        return new Domain.Entities.User
        {
            // Id = record.Id,
            // Email = record.Email,
            // Username = record.Username,
            // FailedLoginAttempts = record.FailedLoginAttempts,
            // LockUntil = record.LockedUntil,
            // PasswordHash = record.Password
        };
    }

    public static void UpdateFromDomain(
        this Persistence.Records.User record,
        Domain.Entities.User user)
    {
        record.Username = user.Username.Value;
        record.Email = user.Email.Value;
        record.FirstName = user.FirstName;
        record.LastName = user.LastName;
        record.Password = user.PasswordHash;
    }
}

