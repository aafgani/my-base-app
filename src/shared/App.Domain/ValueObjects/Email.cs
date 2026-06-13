using System;
using App.Domain.Exceptions;

namespace App.Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (!value.Contains('@'))
            throw new InvalidEmailExceptions(value);

        return new Email(value);
    }
}
