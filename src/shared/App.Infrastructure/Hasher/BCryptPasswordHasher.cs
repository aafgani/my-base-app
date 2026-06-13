using System;
using App.Core.Interface;

namespace App.Infrastructure.Hasher;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        throw new NotImplementedException();
    }

    public bool Verify(string hash, string password)
    {
        throw new NotImplementedException();
    }
}
