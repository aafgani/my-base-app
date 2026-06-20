using System;
using App.Domain.Ids;
using App.Domain.Seedwork;
using App.Domain.ValueObjects;

namespace App.Domain.Entities.Users;

public class User : AggregateRoot<UserId>, IAuditable
{
    public User()
    {
    }
    public UserId Id { get; private set; }
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public int FailedLoginAttempts { get; private set; }
    public DateTime LockUntil { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    private readonly List<UserRole> _roles = [];
    public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();

    public static User Create(
    Username username,
    Email email,
    string passwordHash)
    {
        return new User
        {
            Id = new UserId(Guid.NewGuid()),
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            IsActive = false,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void RecordFailedLogin()
    {
        FailedLoginAttempts++;
        if (FailedLoginAttempts >= 3)
        {
            LockUntil = DateTime.UtcNow.AddMinutes(15);
        }
    }

    public void RecordSuccessfulLogin()
    {
        FailedLoginAttempts = 0;
    }

    public bool IsLocked()
    {
        return FailedLoginAttempts >= 3 || LockUntil > DateTime.UtcNow; // lockout threshold is 3 attempts or lockout time is in the future
    }
    public bool VerifyPassword(string passwordHash)
    {
        return PasswordHash == passwordHash;
    }
    public void Lock(TimeSpan duration)
    {
        LockUntil = DateTime.UtcNow.Add(duration);
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void ChangePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public void AssignRole(RoleId roleId)
    {
        if (_roles.Any(x => x.RoleId == roleId))
        {
            return;
        }

        _roles.Add(UserRole.Create(roleId));
    }
}
