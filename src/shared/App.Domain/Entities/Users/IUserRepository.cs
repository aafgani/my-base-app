using System;
using App.Domain.Entities.Users.ValueObjects;
using App.Domain.Seedwork;

namespace App.Domain.Entities.Users;

public interface IUserRepository : IRepository<User, UserId>
{
        Task<bool> ExistsByEmailAsync(
                Email email);

        Task<bool> ExistsByUsernameAsync(
            Username username);
}
