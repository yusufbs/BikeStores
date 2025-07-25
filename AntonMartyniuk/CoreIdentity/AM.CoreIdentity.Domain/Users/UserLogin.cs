using Microsoft.AspNetCore.Identity;

namespace AM.CoreIdentity.Domain.Users;

public class UserLogin : IdentityUserLogin<string>
{
    public User User { get; set; }
}