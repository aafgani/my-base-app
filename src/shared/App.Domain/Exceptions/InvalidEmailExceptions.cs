using System;

namespace App.Domain.Exceptions;

public sealed class InvalidEmailExceptions : DomainException
{
    public InvalidEmailExceptions(string email) : base($"Invalid email format: {email}", "INVALID_EMAIL")
    {
    }
}
