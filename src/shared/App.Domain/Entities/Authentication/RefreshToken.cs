using System;
using App.Domain.Entities.Authentication.ValueObjects;
using App.Domain.Entities.Users.ValueObjects;
using App.Domain.Seedwork;

namespace App.Domain.Entities.Authentication;

public class RefreshToken : AggregateRoot<RefreshTokenId>, IAuditable
{
    public RefreshTokenId Id { get; private set; }
    public UserId UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public bool IsExpired => ExpiresAt <= DateTime.UtcNow;
    public bool IsRevoked => RevokedAt.HasValue;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static RefreshToken Create(UserId userId, string token, DateTime expiresAt)
    {
        return new RefreshToken
        {
            Id = new RefreshTokenId(Guid.NewGuid()),
            UserId = userId,
            ExpiresAt = expiresAt,
            Token = token,
            CreatedAt = DateTime.UtcNow
        };
    }
}
