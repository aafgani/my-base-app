using App.Domain.Entities;

namespace App.Domain.Specifications.Login;

public class UserEligibleForLoginSpecification : BaseSpecification<User>
{
    public UserEligibleForLoginSpecification(
        string username)
        : base(u => u.Username == username
            && u.IsActive
            && !u.IsLocked())
    {
    }
}
