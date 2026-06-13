using System;
using App.Core.Interface;

namespace App.Core.UseCase;

public class LoginService
{
    // private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginService(IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
    {
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }


}
