using Microsoft.AspNet.Identity.EntityFramework;

namespace AM.CoreIdentity.Domain.Users;

public class UserClaim : IdentityUserClaim<string>
{
    public User User { get; set; }
}

