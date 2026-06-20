using App.Domain.Entities.Users;
using App.Domain.Ids;
using App.Domain.ValueObjects;

namespace App.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User, UserId>, IUserRepository
{
    // public UserRepository(AppDbContext context) : base(context)
    // {
    // }

    // public async Task<bool> ExistsByEmailAsync(Email email)
    // {
    //     return await _context.Users
    //        .AnyAsync(x => x.Email == email.Value);
    // }

    // public async Task<bool> ExistsByUsernameAsync(Username username)
    // {
    //     return await _context.Users
    //         .AnyAsync(x => x.Username == username.Value);
    // }
    public Task<bool> ExistsByEmailAsync(Email email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByUsernameAsync(Username username)
    {
        throw new NotImplementedException();
    }
}