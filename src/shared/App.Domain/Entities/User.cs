using System;

namespace App.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }

    public int FailedLoginAttempts { get; set; }
    public DateTime Lockuntil { get; set; }

    public void IncrementFailedLoginAttempts()
    {
        FailedLoginAttempts++;
    }
    public void ResetFailedLoginAttempts()
    {
        FailedLoginAttempts = 0;
    }
    public bool IsLocked()
    {
        return FailedLoginAttempts >= 3 || Lockuntil > DateTime.UtcNow; // lockout threshold is 3 attempts or lockout time is in the future
    }
    public bool VerifyPassword(string passwordHash)
    {
        return PasswordHash == passwordHash;
    }
}
