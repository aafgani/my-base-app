using App.Core.Interface;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Domain.ValueObjects;

namespace App.Core.UseCase.RegisterUser;

public class RegisterUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public async Task<Guid> RegisterAsync(
        RegisterUserRequest request)
    {
        var email = Email.Create(request.Email);

        var username = Username.Create(request.Username);

        if (await _userRepository.ExistsByEmailAsync(email))
        {
            throw new InvalidDataException("Email already exists.");
        }

        if (await _userRepository.ExistsByUsernameAsync(username))
        {
            throw new InvalidDataException("Username already exists.");
        }

        var user = User.Create(
            username,
            email,
            request.FirstName,
            request.LastName,
            _passwordHasher.Hash(request.Password)
            );

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}
