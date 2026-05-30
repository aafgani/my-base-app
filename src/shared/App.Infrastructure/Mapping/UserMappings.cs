using System;
using App.Domain.Entities;
using App.Infrastructure.Persistence.Records;

namespace App.Infrastructure.Mapping;

public static class UserMappings
{
    public static User MapToDomain(this UserRecord record)
    {
        return new User
        {
            Id = record.Id,
            Email = record.Email,
            Username = record.Username,
            FailedLoginAttempts = record.FailedLoginAttempts,
            PasswordHash = record.PasswordHash
        };
    }

    public static void UpdateFromDomain(
        this UserRecord record,
        User user)
    {
        record.Username = user.Username;
        record.Email = user.Email;
        record.FirstName = user.FirstName;
        record.LastName = user.LastName;
        record.PasswordHash = user.PasswordHash;
    }
}

