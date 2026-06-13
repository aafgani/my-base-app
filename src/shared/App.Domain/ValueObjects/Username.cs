using System;

namespace App.Domain.ValueObjects;

public sealed class Username
{
    public string Value { get; }

    private Username(string value)
    {
        Value = value;
    }

    public static Username Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidDataException("Username is required.");

        value = value.Trim();

        if (value.Length < 3)
            throw new InvalidDataException("Username too short.");

        return new Username(value);
    }

    public override string ToString() => Value;

}
