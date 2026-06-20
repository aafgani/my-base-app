using System;
using App.Domain.Ids;
using App.Domain.Seedwork;
using App.Domain.ValueObjects;

namespace App.Domain.Entities.Users;

public interface IUserRepository : IRepository<User, UserId>
{
        Task<bool> ExistsByEmailAsync(
                Email email);

        Task<bool> ExistsByUsernameAsync(
            Username username);
}
