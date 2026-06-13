using System;

namespace App.Domain.Interface;

public interface IAuditable
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
}
