using App.Domain.Entities;
using App.Infrastructure.Persistence.Contexts;

namespace App.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
