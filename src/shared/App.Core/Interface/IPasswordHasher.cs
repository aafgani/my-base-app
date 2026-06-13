using System;

namespace App.Core.Interface;

public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string hash, string password);

}
