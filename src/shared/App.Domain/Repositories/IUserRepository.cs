using System;
using App.Domain.Entities;
using App.Domain.ValueObjects;

namespace App.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ExistsByEmailAsync(
            Email email);

    Task<bool> ExistsByUsernameAsync(
        Username username);
}
