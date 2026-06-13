using System;
using App.Domain.Entities;

namespace App.Core.Interface;

public interface ITokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}
