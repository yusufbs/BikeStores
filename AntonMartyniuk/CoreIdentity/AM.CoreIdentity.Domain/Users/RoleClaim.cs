using Microsoft.AspNetCore.Identity;

namespace AM.CoreIdentity.Domain.Users;

public class RoleClaim : IdentityRoleClaim<string>
{
    public Role Role { get; set; }
}
