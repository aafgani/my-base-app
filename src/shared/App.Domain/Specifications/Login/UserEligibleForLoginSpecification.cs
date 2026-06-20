using App.Domain.Entities.Users;
using App.Domain.Ids;

namespace App.Domain.Specifications.Login;

public class UserEligibleForLoginSpecification : BaseSpecification<User, UserId>
{
    public UserEligibleForLoginSpecification(
        string username)
        : base(u => u.Username.Value.Equals(username)
            && u.IsActive
            && !u.IsLocked())
    {
    }
}
