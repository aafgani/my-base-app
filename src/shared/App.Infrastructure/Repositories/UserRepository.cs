using App.Domain.Entities;
using App.Domain.Repositories;
using App.Domain.ValueObjects;
using App.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByEmailAsync(Email email)
    {
        return await _context.Users
           .AnyAsync(x => x.Email == email.Value);
    }

    public async Task<bool> ExistsByUsernameAsync(Username username)
    {
        return await _context.Users
            .AnyAsync(x => x.Username == username.Value);
    }
}