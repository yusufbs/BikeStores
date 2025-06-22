using Microsoft.AspNet.Identity.EntityFramework;

namespace AM.CoreIdentity.Domain.Users;

public class UserLogin : IdentityUserLogin<string>
{
    public User User { get; set; }
}