using Microsoft.AspNetCore.Identity;

namespace AM.CoreIdentity.Domain.Users;

public class UserToken : IdentityUserToken<string>
{
    public User User { get; set; }
}
