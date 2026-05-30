using System;
using App.Domain.Entities;
using Shouldly;

namespace App.Domain.Tests.Entities.UserTests;

public class IsLocked
{
    [Fact]
    public void IsLocked_ShouldReturnFalse_WhenFailedAttemptsLessThanThree()
    {
        // Arrange
        var user = new User
        {
            FailedLoginAttempts = 2
        };

        // Act
        var result = user.IsLocked();

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsLocked_ShouldReturnTrue_WhenFailedAttemptsEqualToThree()
    {
        // Arrange
        var user = new User
        {
            FailedLoginAttempts = 3
        };

        // Act
        var result = user.IsLocked();

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsLocked_ShouldReturnTrue_WhenFailedAttemptsGreaterThanThree()
    {
        // Arrange
        var user = new User
        {
            FailedLoginAttempts = 5
        };

        // Act
        var result = user.IsLocked();

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsLocked_ShouldReturnTrue_WhenLockuntilIsInFuture()
    {
        // Arrange
        var user = new User
        {
            Lockuntil = DateTime.UtcNow.AddHours(1)
        };

        // Act
        var result = user.IsLocked();

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsLocked_ShouldReturnFalse_WhenLockuntilIsInPast()
    {
        // Arrange
        var user = new User
        {
            Lockuntil = DateTime.UtcNow.AddHours(-1)
        };

        // Act
        var result = user.IsLocked();

        // Assert
        result.ShouldBeFalse();
    }
}
