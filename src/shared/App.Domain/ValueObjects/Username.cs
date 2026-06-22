using System;
using App.Domain.Seedwork;

namespace App.Domain.ValueObjects;

public class Username : ValueObject
{
    public string Value { get; }

    public Username(string value)
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

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
