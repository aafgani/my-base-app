using System;
using App.Domain.Exceptions;
using App.Domain.Seedwork;

namespace App.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    public Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (!value.Contains('@'))
            throw new InvalidEmailExceptions(value);

        return new Email(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
